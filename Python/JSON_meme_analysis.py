from typing import Tuple, Any
import json

def load_memes(filename: str) -> dict[str, Any]:

    with open(filename) as file:
        memes: dict[str, Any] = json.load(file)
        return memes


def best_average_subreddit(memes: dict[str, Any]) -> str:

  sum = 0
  times = 0
  prev_subreddit = memes["memes"][0]["subreddit"]
  max_average = 0

  for meme in memes["memes"]:

    if meme["subreddit"] == prev_subreddit:
      sum += meme["ups"]
      times += 1
      prev_subreddit = meme["subreddit"]

    else:
      average = sum / times

      if average > max_average:
        max_average = average
        max_subreddit = prev_subreddit

      sum = meme["ups"]
      times = 1
      prev_subreddit = meme["subreddit"]

    average = sum / times

    if average > max_average:
      max_average = average
      max_subreddit = prev_subreddit
      
  return max_subreddit

def best_from_subreddit(subreddit: str, memes: dict[str, Any]) -> str:

  max_ups = memes["memes"][0]["ups"]
  max_url = memes["memes"][0]["postLink"]

  for meme in memes["memes"]:

    if meme["subreddit"] == subreddit:

      if meme["ups"] > max_ups:
        max_ups = meme["ups"]
        max_url = meme["postLink"]

  return max_url

def best_meme(memes: dict[str, Any]) -> str:

  max_ups = memes["memes"][0]["ups"]
  max_url = memes["memes"][0]["postLink"]

  for meme in memes["memes"]:

    if meme["ups"] > max_ups:
      max_ups = meme["ups"]
      max_url = meme["postLink"]

  return max_url

def analyze_memes(fileName: str) -> Tuple[str, str, str]:

    memes = load_memes(fileName)
    best_subreddit = best_average_subreddit(memes)
    bestSub_url = best_from_subreddit(best_subreddit, memes)
    best_url = best_meme(memes)

    return (best_subreddit, bestSub_url, best_url)


print(analyze_memes("memes_KSI.json"))
