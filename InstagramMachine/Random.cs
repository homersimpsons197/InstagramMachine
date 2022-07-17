using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramMachine
{
    internal class Random
    {
        String hashtags;
        String hashtagLike;

        public void Sleep()
        {
            System.Random randomSleep = new System.Random();
            int sleep = randomSleep.Next(1, 5);

            switch (sleep)
            {
                case 1:
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Thread.Sleep(3000);
                    break;
                case 3:
                    Thread.Sleep(4000);
                    break;
                case 4:
                    Thread.Sleep(5000);
                    break;
                case 5:
                    Thread.Sleep(3000);
                    break;
            }
        }

        public void Hashtag(String path)
        {
            hashtags = "";
            String[] hashtagsArr = File.ReadAllLines(String.Format(@"{0}\hashtags.txt", path));

            System.Random randomNbHashtags = new System.Random();
            int nbOfHashtags = randomNbHashtags.Next(10, 25);

            System.Random randomHashtags = new System.Random();
            
            for (int i = 0; i < nbOfHashtags; i++)
            {
                int randomHashtag = randomHashtags.Next(0, hashtagsArr.Length);
                hashtags += hashtagsArr[randomHashtag] + " ";
            }
        }

        public void HashtagLike(String path)
        {
            String[] hashtagLikeArr = File.ReadAllLines(String.Format(@"{0}\hashtags.txt", path));

            System.Random randomHashtagLike = new System.Random();
            int hashtagToLike = randomHashtagLike.Next(1, hashtagLikeArr.Length);

            String hashtagLikeRaw = hashtagLikeArr[hashtagToLike];
            hashtagLike = hashtagLikeRaw.Replace("#", "");
        }

        public String GetHashtags()
        {
            return hashtags;
        }

        public String GetHashtagToLike()
        {
            return hashtagLike;
        }
    }
}
