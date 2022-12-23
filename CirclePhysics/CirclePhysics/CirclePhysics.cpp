#include <iostream>
#include "olcConsoleGameEngine.h"

using namespace std;


struct sBall
{
    float px, py;
    float vx, vy;
    float ax, ay;
    float radius;

    int id;
};

class CirclePhysics : public olcConsoleGameEngine
{
public:
    CirclePhysics()
    {
        m_sAppName = L"Circle Physics";
    }

private:
    vector<pair<float, float>> modelCircle;
    vector<sBall> vecBalls;


    sBall* pSelectedBall = nullptr;

    void AddBall(float x, float y, float r = 5.0f)
    {
        sBall b;
        b.px = x; b.py = y;
        b.vx = 0; b.vy = 0;
        b.ax = 0; b.ay = 0;
        b.radius = r;

        b.id = vecBalls.size();
        vecBalls.emplace_back(b);
    }



public:
    bool OnUserCreate()
    {
        modelCircle.push_back({ 0.0f, 0.0f });
        int nPoints = 20;

        for (int i = 0; i < nPoints; i++)
            modelCircle.push_back({ cosf(i / (float)(nPoints - 1) * 2.0f * 3.14159f), sinf(i / (float)(nPoints - 1) * 2.0f * 3.14159) });

        float fDefaultRad = 8.0f;

        AddBall(ScreenWidth() * 0.25f, ScreenHeight() * 0.5f,fDefaultRad);
        AddBall(ScreenWidth() * 0.75f, ScreenHeight() * 0.5f, fDefaultRad);



        return true;
    }

    bool OnUserUpdate(float fElapsedTime)
    {
        auto DoCirclesOverlap = [](float x1, float y1, float r1, float x2, float y2, float r2)
        {
            return fabs((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) <= (r1 + r2) * (r1 + r2);
        };

        auto IsPointInCircle = [](float x1, float y1, float r1, float px, float py)
        {
            return fabs((x1 - px) * (x1 - px) + (y1 - py) * (y1 - py)) < (r1 * r1);
        };

        // MOUSE CONTROLS

        if (m_mouse[0].bPressed)
        {
            pSelectedBall = nullptr;
            for (auto& ball : vecBalls)
            {
                if (IsPointInCircle(ball.px, ball.py, ball.radius, m_mousePosX, m_mousePosY)) 
                {
                    pSelectedBall = &ball;
                    break;
                }
            }
        }

        if (m_mouse[0].bHeld)
        {
            if (pSelectedBall != nullptr)
            {
                pSelectedBall->px = m_mousePosX;
                pSelectedBall->py = m_mousePosY;
            }
        }

        if (m_mouse[0].bReleased)
        {
            pSelectedBall = nullptr;
        }




        vector<pair<sBall*, sBall*>> vecCollidingPairs;

        // Static collisions
        for (auto &ball : vecBalls)
        {
            for (auto& target : vecBalls) 
            {
                if (ball.id != target.id)
                {
                    if (DoCirclesOverlap(ball.px, ball.py, ball.radius, target.px, target.py, target.radius))
                    {
                        vecCollidingPairs.push_back({ &ball, &target });

                        float fDistance = sqrtf((ball.px - target.px) * (ball.px - target.px) + (ball.py - target.py) * (ball.py - target.py));
                        float fOverlap = 0.5f * (fDistance - ball.radius - target.radius);

                        // Displace ball 1
                        ball.px -= fOverlap * (ball.px - target.px) / fDistance;
                        ball.py -= fOverlap * (ball.py - target.py) / fDistance;

                        // Displace ball 2
                        target.px += fOverlap * (ball.px - target.px) / fDistance;
                        target.py += fOverlap * (ball.py - target.py) / fDistance;

                    }
                }
            }
        }

        for (auto c : vecCollidingPairs) 
        {
            sBall* b1 = c.first;
            sBall* b2 = c.second;
        }



        // Clear Screen
        Fill(0, 0, ScreenWidth(), ScreenHeight(), PIXEL_SOLID, FG_BLACK);

        // Draw Balls
        for (auto ball : vecBalls)
            DrawWireFrameModel(modelCircle, ball.px, ball.py, atan2f(ball.vy, ball.vx), ball.radius, FG_WHITE);

        // Draw line for colliding balls
        for (auto c : vecCollidingPairs)
        {
            DrawLine(c.first->px, c.first->py, c.second->px, c.second->py, PIXEL_SOLID, FG_RED);
        }


        return true;
    }
};

int main()
{
    CirclePhysics demo;
    demo.ConstructConsole(120, 100, 6, 6);
    demo.Start();
}
