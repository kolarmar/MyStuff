#include "olcConsoleGameEngine.h"
#include <fstream>
#include <strstream>
#include <algorithm>

using namespace std;

struct vec3d 
{
    float x = 0;
    float y = 0;
    float z = 0;
    float w = 1;
};

struct triangle {
    vec3d p[3];

    wchar_t sym;
    short col;
};

struct mesh {
    vector<triangle> tris;

    bool LoadFromObjectFile(string sFilename)
    {
        ifstream f(sFilename);
        if (!f.is_open())
            return false; 

        vector<vec3d> verts;

        while (!f.eof())
        {
            char line[128];
            f.getline(line, 128);

            strstream s;
            s << line;

            char junk;

            if (line[0] == 'v')
            {
                vec3d v;
                s >> junk >> v.x >> v.y >> v.z;
                verts.push_back(v);
            }

            if (line[0] == 'f')
            {
                int f[3];
                s >> junk >> f[0] >> f[1] >> f[2];
                tris.push_back({ verts[f[0] - 1], verts[f[1] - 1], verts[f[2] - 1] });
            }
        }

        return true;
    }
};

struct mat4x4
{
    float m[4][4] = { 0 };
};


class olcEngine3D : public olcConsoleGameEngine
{
public:

    olcEngine3D()
    {
        m_sAppName = L"3D Demo";
    }

private:
    mesh meshCube;
    mat4x4 matProj;

    vec3d vCamera;
    vec3d vLookDirection;

    float fYaw;

    float fTheta;

    vec3d Matrix_MultiplyVector(mat4x4& mat, vec3d& i)
    {
        vec3d v;
        v.x = i.x * mat.m[0][0] + i.y * mat.m[1][0] + i.z * mat.m[2][0] + i.w * mat.m[3][0];
        v.y = i.x * mat.m[0][1] + i.y * mat.m[1][1] + i.z * mat.m[2][1] + i.w * mat.m[3][1];
        v.z = i.x * mat.m[0][2] + i.y * mat.m[1][2] + i.z * mat.m[2][2] + i.w * mat.m[3][2];
        v.w = i.x * mat.m[0][3] + i.y * mat.m[1][3] + i.z * mat.m[2][3] + i.w * mat.m[3][3];
        return v;
    }

    mat4x4 Matrix_MakeIdentity()
    {
        mat4x4 matrix;
        matrix.m[0][0] = 1.0f;
        matrix.m[1][1] = 1.0f;
        matrix.m[2][2] = 1.0f;
        matrix.m[3][3] = 1.0f;
        return matrix;
    }

    mat4x4 Matrix_MakeRotationX(float fAngleRad)
    {
        mat4x4 matrix;
        matrix.m[0][0] = 1.0f;
        matrix.m[1][1] = cosf(fAngleRad);
        matrix.m[1][2] = sinf(fAngleRad);
        matrix.m[2][1] = -sinf(fAngleRad);
        matrix.m[2][2] = cosf(fAngleRad);
        matrix.m[3][3] = 1.0f;
        return matrix;
    }

    mat4x4 Matrix_MakeRotationY(float fAngleRad)
    {
        mat4x4 matrix;
        matrix.m[0][0] = cosf(fAngleRad);
        matrix.m[0][2] = sinf(fAngleRad);
        matrix.m[2][0] = -sinf(fAngleRad);
        matrix.m[1][1] = 1.0f;
        matrix.m[2][2] = cosf(fAngleRad);
        matrix.m[3][3] = 1.0f;
        return matrix;
    }

    mat4x4 Matrix_MakeRotationZ(float fAngleRad)
    {
        mat4x4 matrix;
        matrix.m[0][0] = cosf(fTheta);
        matrix.m[0][1] = sinf(fTheta);
        matrix.m[1][0] = -sinf(fTheta);
        matrix.m[1][1] = cosf(fTheta);
        matrix.m[2][2] = 1.0f;
        matrix.m[3][3] = 1.0f;
        return matrix;
    }
    
    mat4x4 Matrix_MakeTranslation(float x, float y, float z)
    {
        mat4x4 matrix = Matrix_MakeIdentity();
        matrix.m[3][0] = x;
        matrix.m[3][1] = y;
        matrix.m[3][2] = z;
        return matrix;
    }

    mat4x4 Matrix_MakeProjection(float fFovDegrees, float fAspectRatio, float fNear, float fFar)
    {
        float fFovRad = 1.0f / tanf(fFovDegrees * 0.5f / 180.0f * 3.14159f);
        mat4x4 matrix;
        matrix.m[0][0] = fAspectRatio * fFovRad;
        matrix.m[1][1] = fFovRad;
        matrix.m[2][2] = fFar / (fFar - fNear);
        matrix.m[2][3] = (-fNear * fFar) / (fFar - fNear);
        matrix.m[3][2] = 1.0f;
        matrix.m[3][3] = 0.0f;
        return matrix;
    }

    mat4x4 Matrix_MultiplyMatrix(mat4x4& m1, mat4x4& m2)
    {
        mat4x4 matrix;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                matrix.m[j][i] = (m1.m[j][0] * m2.m[0][i] +
                                  m1.m[j][1] * m2.m[1][i] +
                                  m1.m[j][2] * m2.m[2][i] +
                                  m1.m[j][3] * m2.m[3][i]);
            }
        }
        return matrix;
    }

    mat4x4 Matrix_PointAt(vec3d& pos, vec3d& target, vec3d& up)
    {
        // Calculate new forward direction
        vec3d newForward = Vector_Sub(target, pos);
        newForward = Vector_Normalize(newForward);

        // Calculate new up direction
        vec3d a = Vector_Mul(newForward, Vector_DotProduct(up, newForward));
        vec3d newUp = Vector_Sub(up, a);
        newUp = Vector_Normalize(newUp);

        // Calculate new right direction
        vec3d newRight = Vector_CrossProduct(newUp, newForward);

        mat4x4 matrix;
        matrix.m[0][0] = newRight.x;
        matrix.m[1][0] = newUp.x;
        matrix.m[2][0] = newForward.x;
        matrix.m[3][0] = pos.x;

        matrix.m[0][1] = newRight.y;
        matrix.m[1][1] = newUp.y;
        matrix.m[2][1] = newForward.y;
        matrix.m[3][1] = pos.y;

        matrix.m[0][2] = newRight.z;
        matrix.m[1][2] = newUp.z;
        matrix.m[2][2] = newForward.z;
        matrix.m[3][2] = pos.z;

        matrix.m[0][3] = 0.0f;
        matrix.m[1][3] = 0.0f;
        matrix.m[2][3] = 0.0f;
        matrix.m[3][3] = 1.0f;

        return matrix;

    }

    mat4x4 Matrix_QuickInverse(mat4x4& m)
    {
        mat4x4 matrix;
        matrix.m[0][0] = m.m[0][0]; matrix.m[0][1] = m.m[1][0]; matrix.m[0][2] = m.m[2][0]; matrix.m[0][3] = 0.0f;
        matrix.m[1][0] = m.m[0][1]; matrix.m[1][1] = m.m[1][1]; matrix.m[1][2] = m.m[2][1]; matrix.m[1][3] = 0.0f;
        matrix.m[2][0] = m.m[0][2]; matrix.m[2][1] = m.m[1][2]; matrix.m[2][2] = m.m[2][2]; matrix.m[2][3] = 0.0f;
        matrix.m[3][0] = -(m.m[3][0] * matrix.m[0][0] + m.m[3][1] * matrix.m[1][0] + m.m[3][2] * matrix.m[2][0]);
        matrix.m[3][1] = -(m.m[3][0] * matrix.m[0][1] + m.m[3][1] * matrix.m[1][1] + m.m[3][2] * matrix.m[2][1]);
        matrix.m[3][2] = -(m.m[3][0] * matrix.m[0][2] + m.m[3][1] * matrix.m[1][2] + m.m[3][2] * matrix.m[2][2]);
        matrix.m[3][3] = 1.0f;
        return matrix;
    }

    vec3d Vector_Add(vec3d& v1, vec3d& v2)
    {
        return { v1.x + v2.x, v1.y + v2.y, v1.z + v2.z };
    }

    vec3d Vector_Sub(vec3d& v1, vec3d& v2)
    {
        return { v1.x - v2.x, v1.y - v2.y, v1.z - v2.z };
    }

    vec3d Vector_Mul(vec3d& v1, float k)
    {
        return { v1.x * k, v1.y * k, v1.z * k };
    }

    vec3d Vector_Div(vec3d& v1, float k)
    {
        return { v1.x / k, v1.y / k, v1.z / k };
    }

    float Vector_DotProduct(vec3d& v1, vec3d& v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }

    float Vector_Length(vec3d& v1)
    {
        return sqrtf(Vector_DotProduct(v1, v1));
    }

    vec3d Vector_Normalize(vec3d& v1)
    {
        float l = Vector_Length(v1);
        return { v1.x / l, v1.y / l, v1.z / l };
    }

    vec3d Vector_CrossProduct(vec3d& v1, vec3d& v2)
    {
        vec3d v;
        v.x = v1.y * v2.z - v1.z * v2.y;
        v.y = v1.z * v2.x - v1.x * v2.z;
        v.z = v1.x * v2.y - v1.y * v2.x;
        return v;
    }

    CHAR_INFO GetColour(float lum)
    {
        short bg_col, fg_col;
        wchar_t sym;
        int pixel_bw = (int)(13.0f * lum);
        switch (pixel_bw)
        {
        case 0: bg_col = BG_BLACK; fg_col = FG_BLACK; sym = PIXEL_SOLID; break;

        case 1: bg_col = BG_BLACK; fg_col = FG_DARK_GREY; sym = PIXEL_QUARTER; break;
        case 2: bg_col = BG_BLACK; fg_col = FG_DARK_GREY; sym = PIXEL_HALF; break;
        case 3: bg_col = BG_BLACK; fg_col = FG_DARK_GREY; sym = PIXEL_THREEQUARTERS; break;
        case 4: bg_col = BG_BLACK; fg_col = FG_DARK_GREY; sym = PIXEL_SOLID; break;

        case 5: bg_col = BG_DARK_GREY; fg_col = FG_GREY; sym = PIXEL_QUARTER; break;
        case 6: bg_col = BG_DARK_GREY; fg_col = FG_GREY; sym = PIXEL_HALF; break;
        case 7: bg_col = BG_DARK_GREY; fg_col = FG_GREY; sym = PIXEL_THREEQUARTERS; break;
        case 8: bg_col = BG_DARK_GREY; fg_col = FG_GREY; sym = PIXEL_SOLID; break;

        case 9:  bg_col = BG_GREY; fg_col = FG_WHITE; sym = PIXEL_QUARTER; break;
        case 10: bg_col = BG_GREY; fg_col = FG_WHITE; sym = PIXEL_HALF; break;
        case 11: bg_col = BG_GREY; fg_col = FG_WHITE; sym = PIXEL_THREEQUARTERS; break;
        case 12: bg_col = BG_GREY; fg_col = FG_WHITE; sym = PIXEL_SOLID; break;
        default:
            bg_col = BG_BLACK; fg_col = FG_BLACK; sym = PIXEL_SOLID;
        }

        CHAR_INFO c;
        c.Attributes = bg_col | fg_col;
        c.Char.UnicodeChar = sym;
        return c;
    }

public:

    bool OnUserCreate() override
    {

        meshCube.LoadFromObjectFile("axis.obj");

        matProj = Matrix_MakeProjection(160.0f, (float)ScreenHeight() / (float)ScreenWidth(), 0.1f, 1000.0f);

        return true;
    }

    bool OnUserUpdate(float fElapsedTime) override
    {
        if (GetKey(VK_UP).bHeld)
            vCamera.y += 8.0f * fElapsedTime;

        if (GetKey(VK_DOWN).bHeld)
            vCamera.y -= 8.0f * fElapsedTime;

        if (GetKey(VK_LEFT).bHeld)
            vCamera.x += 8.0f * fElapsedTime;

        if (GetKey(VK_RIGHT).bHeld)
            vCamera.x -= 8.0f * fElapsedTime;

        vec3d vForward = Vector_Mul(vLookDirection, 8.0f * fElapsedTime);

        if (GetKey(L'W').bHeld)
            vCamera = Vector_Add(vCamera, vForward);

        if (GetKey(L'S').bHeld)
            vCamera = Vector_Sub(vCamera, vForward);


        if (GetKey(L'A').bHeld)
            fYaw -= 2.0f * fElapsedTime;

        if (GetKey(L'D').bHeld)
            fYaw += 2.0f * fElapsedTime;



        Fill(0, 0, ScreenWidth(), ScreenHeight(), PIXEL_SOLID, FG_BLACK);

        mat4x4 matRotZ, matRotX;
        //fTheta += 1.0f * fElapsedTime;

        matRotX = Matrix_MakeRotationX(fTheta * 0.5f);
        matRotZ = Matrix_MakeRotationZ(fTheta);

        mat4x4 matTrans;
        matTrans = Matrix_MakeTranslation(0.0f, 0.0f, 15.0f);

        mat4x4 matWorld;
        matWorld = Matrix_MakeIdentity();
        matWorld = Matrix_MultiplyMatrix(matRotX, matRotZ);
        matWorld = Matrix_MultiplyMatrix(matWorld, matTrans);

        vec3d vUp = { 0,1,0 };
        vec3d vTarget = { 0,0,1 };
        mat4x4 matCameraRot = Matrix_MakeRotationY(fYaw);
        vLookDirection = Matrix_MultiplyVector(matCameraRot, vTarget);
        vTarget = Vector_Add(vCamera, vLookDirection);

        mat4x4 matCamera = Matrix_PointAt(vCamera, vTarget, vUp);
        mat4x4 matView = Matrix_QuickInverse(matCamera);

        vector<triangle> vecTrianglesToRaster;

        for (auto tri : meshCube.tris)
        {
            triangle triProjected, triTransformed, triViewed;

            triTransformed.p[0] = Matrix_MultiplyVector(matWorld, tri.p[0]);
            triTransformed.p[1] = Matrix_MultiplyVector(matWorld, tri.p[1]);
            triTransformed.p[2] = Matrix_MultiplyVector(matWorld, tri.p[2]);

            // Calculate normals in 3D
            vec3d normal, line1, line2;
            
            line1 = Vector_Sub(triTransformed.p[1], triTransformed.p[0]);
            line2 = Vector_Sub(triTransformed.p[2], triTransformed.p[0]);

            // Cross Product of lines = normal vector
            normal = Vector_CrossProduct(line1, line2);

            normal = Vector_Normalize(normal);

            // Get ray from camera to triangle
            vec3d vCameraRay = Vector_Sub(triTransformed.p[0], vCamera);

            if (Vector_DotProduct(normal, vCameraRay) < 0.0f)
            {
                // Illumination
                vec3d light_direction = { 0.0f, 0.0f, -1.0f };
                light_direction = Vector_Normalize(light_direction);

                // How simillar/alligned are light direction and normal vectors
                float dp = max(0.1f,Vector_DotProduct(light_direction, normal));

                // Console colours
                CHAR_INFO c = GetColour(dp);
                triTransformed.col = c.Attributes;
                triTransformed.sym = c.Char.UnicodeChar;

                // Convert World Space to View Space
                triViewed.p[0] = Matrix_MultiplyVector(matView, triTransformed.p[0]);
                triViewed.p[1] = Matrix_MultiplyVector(matView, triTransformed.p[1]);
                triViewed.p[2] = Matrix_MultiplyVector(matView, triTransformed.p[2]);
                triViewed.sym = triTransformed.sym;
                triViewed.col = triTransformed.col;


                // 3D -> 2D PROJECTION
                triProjected.p[0] = Matrix_MultiplyVector(matProj, triViewed.p[0]);
                triProjected.p[1] = Matrix_MultiplyVector(matProj, triViewed.p[1]);
                triProjected.p[2] = Matrix_MultiplyVector(matProj, triViewed.p[2]);
                triProjected.col = triViewed.col;
                triProjected.sym = triViewed.sym;

                // Divide by "z" depth. "w" represents z coordinate in 3D
                triProjected.p[0] = Vector_Div(triProjected.p[0], triProjected.p[0].w);
                triProjected.p[1] = Vector_Div(triProjected.p[1], triProjected.p[1].w);
                triProjected.p[2] = Vector_Div(triProjected.p[2], triProjected.p[2].w);

                // Scale into view
                vec3d vOffsetView = { 1,1,0 };
                triProjected.p[0] = Vector_Add(triProjected.p[0], vOffsetView);
                triProjected.p[1] = Vector_Add(triProjected.p[1], vOffsetView);
                triProjected.p[2] = Vector_Add(triProjected.p[2], vOffsetView);

                triProjected.p[0].x *= 0.5f * (float)ScreenWidth();
                triProjected.p[0].y *= 0.5f * (float)ScreenWidth();

                triProjected.p[1].x *= 0.5f * (float)ScreenWidth();
                triProjected.p[1].y *= 0.5f * (float)ScreenWidth();

                triProjected.p[2].x *= 0.5f * (float)ScreenWidth();
                triProjected.p[2].y *= 0.5f * (float)ScreenWidth();

                // Store triangle for sorting
                vecTrianglesToRaster.push_back(triProjected);

            }
        }

        // Sort triangles from back to front
        sort(vecTrianglesToRaster.begin(), vecTrianglesToRaster.end(), [](triangle& t1, triangle& t2)
            {
                float z1 = (t1.p[0].z + t1.p[1].z + t1.p[2].z) / 3.0f;
                float z2 = (t2.p[0].z + t2.p[1].z + t2.p[2].z) / 3.0f;
                return z1 > z2;
            });

        // Rasterize triangles
        for (auto& triProjected : vecTrianglesToRaster)
        {
            FillTriangle(triProjected.p[0].x, triProjected.p[0].y,
                triProjected.p[1].x, triProjected.p[1].y,
                triProjected.p[2].x, triProjected.p[2].y,
                triProjected.sym, triProjected.col);

            /*DrawTriangle(triProjected.p[0].x, triProjected.p[0].y,
                triProjected.p[1].x, triProjected.p[1].y,
                triProjected.p[2].x, triProjected.p[2].y,
                PIXEL_SOLID, FG_BLACK);*/
        }

        return true;
    }
};

int main()
{
    olcEngine3D demo;
    if (demo.ConstructConsole(250, 220, 2, 2))
        demo.Start();
    return 0;
}
