def word_frequency(text):
    text = text.lower()
    array = []
    word = ""
    trash = ""
    for letter in text:
        if letter.isalpha() == True:
            word += letter
        else:
            if word == "":
                continue
            else:
                trash += letter
                array.append(word)
                word = ""
    if word != "":
        array.append(word)


    dictionary = {}
    for name in array:
        if name in dictionary:
            dictionary[name] += 1
        else:        
            dictionary[name] = 1
    return dictionary


# testy (upravujte dle libosti)
print(word_frequency("Ksi, Ksa, Ksi, Kse"))       # {'ksi': 2, 'ksa': 1, 'kse': 1}
print(word_frequency("Ksi,+Ksa,Ksi;;-;Kse_"))     # {'ksi': 2, 'ksa': 1, 'kse': 1}
print(word_frequency("Informatika je nejlepsi"))  # {'informatika': 1, 'je': 1, 'nejlepsi': 1}

