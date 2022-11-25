import os
import discord
from discord.ext import commands
from dotenv import load_dotenv

LIKE_EMOJI = "👍"
DISLIKE_EMOJI = "👎"

load_dotenv()
TOKEN = os.getenv('DISCORD_TOKEN')

intents = discord.Intents.default()
intents.message_content = True

bot = commands.Bot(command_prefix="!", intents=intents)

@bot.event
async def on_ready() -> None:
    print(bot.user)

@bot.command()
async def poll(ctx: commands.Context, question: str, answ1: str, answ2: str):
    bot_response = f'{question}\n{LIKE_EMOJI + answ1}\n{DISLIKE_EMOJI + answ2}'
    poll_reaction = await ctx.send(bot_response)
    await poll_reaction.add_reaction(LIKE_EMOJI)
    await poll_reaction.add_reaction(DISLIKE_EMOJI)


bot.run(TOKEN)    
