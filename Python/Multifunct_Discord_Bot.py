
from os import getenv
import os
import random
import requests

from discord import Intents, Message
from discord.ext import commands
from discord.ext.commands import Context
from dotenv import load_dotenv
from notifiers import get_notifier


load_dotenv()
TOKEN = getenv("DISCORD_TOKEN")
IMGFLIP_API_URL = "https://api.imgflip.com"

user_name = getenv("USER_NAME")
password = getenv("PASSWORD")

intents = Intents.default()
intents.message_content = True

bot = commands.Bot(
    command_prefix="!", case_insensitive=True, intents=intents
)




class MemeGenerator:

    def list_memes(self) -> str:

        response = requests.get("https://api.imgflip.com/get_memes")

        meme_list = response.json()

        i = 0
        final_string = ""

        for meme in meme_list["data"]["memes"]:

            final_string = final_string + meme["id"] + " " + meme["name"] + "\n"
            i += 1

            if i == 25:
                break

        return final_string

    def make_meme(
        self, template_id: int, top_text: str, bottom_text: str
    ) -> str:

        username = "karlikbot"
        password = "passw0rD"

        params = {"template_id": template_id, "username": username, "password": password, "text0": top_text, "text1": bottom_text}

        response = requests.post("https://api.imgflip.com/caption_image", params=params)
        
        url: str = response.json()["data"]["url"]

        return url


class MentionsNotifier:

    

    def __init__(self) -> None:

        self.saved_emails: dict[int: str] = {}
        


    def subscribe(self, user_id: int, email: str) -> None:

        if user_id in self.saved_emails:
            del self.saved_emails[user_id]
            
        self.saved_emails[user_id] = email


    def unsubscribe(self, user_id: int) -> None:
        
        del self.saved_emails[user_id]


    def notify_about_mention(self, user_id: int, msg_content: str) -> None:

        email = get_notifier('email')

        settings = {
            'host': 'ksi2022smtp.iamroot.eu',
            'port': 465,
            'ssl': True,

            'username': user_name,
            'password': password,

            'to': self.saved_emails[user_id],
            'from': user_name,

            'subject':"Discord notification",
            'message': msg_content,
        }

        email.notify(**settings)
        


class Hangman:

    def __init__(self) -> None:

        #  imports and creates a list from the "words.txt" file
        #  pathway was necessary to specify, otherwise python couldn't find "words.txt"
        os.chdir(r'C:\Users\Games\learnpython\Vlna1\Meme_Bot')
        with open("words.txt", "r") as file:
            for line in file:
                self.words = file.readlines() 

        #  cuts the "\n" away from the words
        i = 0
        while i < len(self.words) - 1:
            self.words[i] = self.words[i][0:len(self.words[i]) - 1]
            i += 1



        self.lives: int = 7

        #  this is will be filled with a random word when !play_hangman is called
        self.word: str = ""

        # this will be filled after the word is chosen
        self.dashes: str = ""

        self.guesses: str = ""

        self.player: str = ""

        self.core_message = f"**Hangman**\nPlayer: {self.player}\nGuesses: {self.guesses}\nLives: {self.lives}\nWord: {self.dashes}"

        self.msg: Message

        self.last_line: str = ""

        self.guessed_times: int = 1

        self.game_on: bool = False

        self.word_list: list[str]  = []
        self.dashes_list: list[str] = []



@bot.event
async def on_ready():
    print("Meme bot online")



# --------- LEVEL 1 ----------
meme_generator = MemeGenerator()


@bot.command(name="list_memes")
async def list_memes(ctx: Context) -> None:

    meme_list = meme_generator.list_memes()
    await ctx.send(f"```{meme_list}```")


@bot.command(name="make_meme")
async def make_meme(
    ctx: Context, template_id: int, top_text: str, bottom_text: str
) -> None:

    meme_url = meme_generator.make_meme(template_id, top_text, bottom_text)
    await ctx.send(meme_url)



# --------- LEVEL 2 ----------
mentions_notifier = MentionsNotifier()


@bot.command(name="subscribe")
async def subscribe(ctx: Context, email: str) -> None:
    mentions_notifier.subscribe(ctx.author.id, email)


@bot.command(name="unsubscribe")
async def unsubscribe(ctx: Context) -> None:
    mentions_notifier.unsubscribe(ctx.author.id)


@bot.event
async def on_message(message: Message) -> None:

    if len(message.mentions) > 0:
        for member in message.mentions:
            mentions_notifier.notify_about_mention(member.id, f"Someone mentioned you in channel {message.jump_url}")

    await bot.process_commands(message)


# --------- LEVEL 3 ----------
hangman = Hangman()


@bot.command(name="play_hangman")
async def play_hangman(ctx: Context) -> None:

    #  sets the player
    hangman.player = ctx.author.name

    #  sets / resets values
    hangman.lives = 7
    hangman.guessed_times = 1
    hangman.guesses = ""
    hangman.dashes = ""
    hangman.game_on = True
    hangman.dashes_list = []
    hangman.word_list = []

    #  chooses a random word
    rnd_int = random.randint(0, len(hangman.words))
    hangman.word = hangman.words[rnd_int].upper()
    print(hangman.word)


    #  chooses the correct number of dashes for the chosen word
    #  and fills makes a list out of the word
    for letter in hangman.word:
        hangman.dashes_list.append("-")
        hangman.word_list.append(letter)

    print(hangman.dashes_list)
    print(hangman.word_list)


    for dash in hangman.word_list:
        hangman.dashes += " -"
    

    #  updates the core_message variable
    hangman.core_message = f"**Hangman**\nPlayer: {hangman.player}\nGuesses: {hangman.guesses}\nLives: {hangman.lives}\nWord:{hangman.dashes}"

    
    hangman.msg = await ctx.send(hangman.core_message)


    

@bot.command(name="guess")
async def guess(ctx: Context, letter: str) -> None:

    await ctx.message.delete()

    #  checks if the game is on ("!play_hangman" was already called)
    if hangman.game_on == False:
        hangman.core_message = f"You have to start a new game first."
        await ctx.send(hangman.core_message)      

    correct_input: bool = False

    letter = letter.upper()
    
    #  check if input is correct
    if not len(letter) == 1:
        hangman.last_line = "Enter only 1 letter at a time."     

    #  when letter has already been guessed
    if letter in hangman.guesses:
        hangman.last_line = "You already guessed that."

    else:
        correct_input = True



    if correct_input == True:

        #  first guess
        if hangman.guessed_times == 1 :
            hangman.guesses = f"{letter}"

            #  letter is correct
            if letter in hangman.word:
                hangman.last_line = "Correct guess."

                i = 0
                for let in hangman.word_list:
    
                    if let == letter:
                        hangman.dashes_list[i] = let

                    i += 1
                print(hangman.dashes_list)
                #  reset dashes 
                hangman.dashes = ""

                #  tranfer dashlist to dashes str
                for dash in hangman.dashes_list:
                    hangman.dashes += f" {dash}"                
                

            else:
                hangman.last_line = "Wrong guess."  
                hangman.lives -= 1              


        #  next guesses
        if hangman.guessed_times > 1:
            hangman.guesses = f"{letter}, " + hangman.guesses

            #  letter is correct
            if letter in hangman.word:
                hangman.last_line = "Correct guess."

                i = 0
                for let in hangman.word_list:
    
                    if let == letter:
                        hangman.dashes_list[i] = let

                    i += 1
                
                #  reset dashes 
                hangman.dashes = ""

                #  tranfer dashlist to dashes str
                for dash in hangman.dashes_list:
                    hangman.dashes += f" {dash}"      


            else:    
                hangman.last_line = "Wrong guess."              
                hangman.lives -= 1   
            
                

    #  end of game - lost
    if hangman.lives <= 0:
        hangman.last_line = f"You lost! The word was: {hangman.word}"
        hangman.game_on = False



    #  end of game - win
    if "-" not in hangman.dashes:
        hangman.last_line = "You won!"
        hangman.game_on = False
        

    #  add the number of guesses
    hangman.guessed_times += 1

    #  updates the core_message variable
    hangman.core_message = f"**Hangman**\nPlayer: {hangman.player}\nGuesses: {hangman.guesses}\nLives: {hangman.lives}\nWord:{hangman.dashes}\n{hangman.last_line}"

    #  edit the former message with the updated version
    await hangman.msg.edit(content=hangman.core_message)



bot.run(TOKEN)
