import os
import time
import discord
from discord.ext import commands
from dotenv import load_dotenv

load_dotenv()

TOKEN = os.getenv("TOKEN")

class DiscordBot(commands.Bot):
    def __init__(self, command_prefix):
        intents = discord.Intents.default()
        intents.message_content = True
        commands.Bot.__init__(self, command_prefix=command_prefix, self_bot=False, intents=intents)
        self.times_turned = 0
        self.waited = True
        self.artifact = ""
        self.wanted_artifact = "x"
        self.taken_artifact = False

    async def on_ready(self):
        print(bot.user.name + " ONLINE")

    #  fights with all enemies
    async def fight(self, ctx):
        if "**Shade**" in ctx.content:          #  Shade - axe
            await ctx.channel.send("!fight axe")

        if "**Slime**" in ctx.content:          #  Slime - axe
            await ctx.channel.send("!fight axe")

        if "**Vulture**" in ctx.content:          #  Vulture - axe
            await ctx.channel.send("!fight axe")
        
        if "**Hound**" in ctx.content:          #  Hound - sword
            await ctx.channel.send("!fight sword")

        if "**Skeleton**" in ctx.content:          #  Skeleton - sword
            await ctx.channel.send("!fight sword")

        if "**Zombie**" in ctx.content:          #  Zombie - sword
            await ctx.channel.send("!fight sword")

        if "**Ogre**" in ctx.content:          #  Ogre - ?? not axe
            await ctx.channel.send("!fight bow")

        if "**Tarantula**" in ctx.content:          #  Tarantula - bow
            await ctx.channel.send("!fight bow")

        if "**Giant**" in ctx.content:          #  Giant - bow
            await ctx.channel.send("!fight bow")

    async def solve_quest(self, ctx):
        answer: int = 0
        msg: str = ctx.content
        msg = msg.replace("__**Quest**__\nYou need to solve a quest to escape this room. How much is: ", "")
        answer = str(eval(msg))
        await ctx.channel.send("!solve " + answer)

    async def take_artifact(self, ctx):
        msg: str = ctx.content
        msg = msg.replace("_", "")
        msg = msg.replace("*", "")
        msg = msg.replace("\n", "")
        msg = msg.replace("Artifact Room", "")
        msg = msg.replace("You find yourself ", "")
        msg = msg.replace("in an empty room.", "")
        msg = msg.replace(" A/an ", "")
        msg = msg.replace(" lies on the floor.","")

        bot.taken_artifact = True
        await ctx.channel.send("!take")
        bot.artifact = msg
        print(bot.artifact)

    async def needed_artifact_is(self, ctx):
        msg: str = ctx.content
        msg = msg.replace("_", "")
        msg = msg.replace("*", "")
        msg = msg.replace("\n", "")
        msg = msg.replace("Boss Battle", "")
        msg = msg.replace("You stand before a", "")
        msg = msg.replace(" mighty boss.", "")
        msg = msg.replace(" Bring a/an ", "")
        msg = msg.replace(" to overpower him.", "")
        self.wanted_artifact = msg
        print("wanted " + self.wanted_artifact)


    #  MOVEMENT

    async def turn_right(self, ctx):
        await ctx.channel.send("!turn right")
        self.times_turned += 1

    async def turn_left(self, ctx):
        await ctx.channel.send("!turn left")
        self.times_turned += 1
        
    async def move_forward(self, ctx):
        await ctx.channel.send("!step")
        self.times_turned = 0

    async def check_wall(self, ctx):
        await ctx.channel.send("!wall")


    #  MAIN LOOP

    async def on_message(self, ctx):
        if bot.waited == False:
            return

        if ctx.content.startswith("st"):
            await ctx.channel.send("!level 4")
            self.times_turned = 0
            bot.waited = True

        if ctx.content.startswith("re"):
            await ctx.channel.send("!restart")
            self.times_turned = 0
            bot.waited = True
        
        bot.waited = False

        #  on enemy attack
        if ctx.content.startswith("__**Enemy Attack**__"):
            await self.fight(ctx)
        
        #  on empty room
        if ctx.content.startswith("__**Empty Room**__"):
            if self.times_turned == 0:
                await self.turn_right(ctx)
            else:
                await self.check_wall(ctx)


        #  on wall check
        if ctx.content.startswith("__**Wall**__"):
            #  wall - good
            if "can move" in ctx.content:
                await self.move_forward(ctx)
            
            #  wall - bad
            else:
                await self.turn_left(ctx)

        #  on quest
        if ctx.content.startswith("__**Quest**__"):
            await self.solve_quest(ctx)

        #  on artifact
        if ctx.content.startswith("__**Artifact Room**__"):
            #  if I already have the wanted artifact - act as if the room was empty 
            if self.artifact == self.wanted_artifact:         
                if self.times_turned == 0:
                    await self.turn_right(ctx)
                else:
                    await self.check_wall(ctx)
            else:
                #  if artifact was taken from this room - act as if the room was empty
                if self.taken_artifact: 
                    if self.times_turned == 0:
                        await self.turn_right(ctx)
                    else:
                        await self.check_wall(ctx)   
                else:
                    await self.take_artifact(ctx)

       

        #  on boss battle
        if ctx.content.startswith("__**Boss Battle**__"):
            await self.needed_artifact_is(ctx)
            time.sleep(1)
            #  act as if the room was empty          
            if self.times_turned == 0:
                await self.turn_right(ctx)
            else:
                await self.check_wall(ctx)

        #  waits for the game master's response
        time.sleep(1)
        bot.waited = True


bot = DiscordBot("!")
bot.run(TOKEN)
