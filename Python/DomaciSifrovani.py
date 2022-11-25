def encode(n: int, plain_text: str) -> str: # vraci cipher_text typu String
    x = n
    cipher_text = ""
    kousek = plain_text
    while n < len(plain_text):
        kousek = plain_text[n - x:n]
        cipher_text += kousek[::-1]
        kousek = plain_text[n:]
        n += x

    cipher_text += kousek[::-1]
    return cipher_text

def decode(n: int, cipher_text: str) -> str: # vraci plaintext typu String
    x = n
    plain_text = ""
    kousek = cipher_text
    while n < len(cipher_text):
        kousek = cipher_text[n -x:n]
        plain_text += kousek[::-1]
        kousek = cipher_text[n:]
        n += x
    
    plain_text += kousek[::-1]
    return plain_text


# Testy:
print(encode(3, "Ahoj")) # ohAj
print(encode(2, "Ahoj")) # hAjo
print(encode(10, "Ahoj")) # johA
print(encode(3, "12345")) # 32154
print(encode(5, "komunikace")) # numokecaki
print(decode(2, "hAjo")) # Ahoj
print(decode(5, "rgorpavomain")) # programovani
print(decode(3, encode(3, "Karlik a Los Karlos komunikuji sifrovane"))) # Karlik a Los Karlos komunikuji sifrovane
print(decode(18, encode(17, "Martin Kolar")))
# na automaticke testy doporucuji assert

