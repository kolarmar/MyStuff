from typing import List

def is_face_on_photo(photo: List[List[str]]) -> bool:
    isFace = False
    for row in range(len(photo)-1):
        for col in range(len(photo[0])-1):
            if photo[row][col] != 'x':
                    face = []
                    face.append(photo[row][col])
                    face.append(photo[row][col + 1])                
                    face.append(photo[row + 1][col])
                    face.append(photo[row + 1][col + 1])
                    if 'f' in face:
                        if 'a' in face:
                            if 'c' in face:
                                if 'e' in face:
                                    isFace = True
                                    return isFace
    return isFace



# Veřejné testy:
print(is_face_on_photo([['f', 'a'], ['c', 'e']]))  # True
print(is_face_on_photo([['f', 'a', 'c', 'e']]))  # False
print(is_face_on_photo([['e', 'c', 'x'], ['a', 'f', 'x'], ['x', 'x', 'x']]))  # True
print(is_face_on_photo([['f', 'f', 'x'], ['a', 'a', 'x'], ['x', 'x', 'x']]))  # False
print(is_face_on_photo([['x','x','x','x','x','x','f','f'], ['x','x','x','x','x','x','e','a']]))