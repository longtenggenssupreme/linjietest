using System;
using System.Threading;

namespace linjiefirstlib
{
    public class Linjie
    {
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min">最小值，包括边界</param>
        /// <param name="max">最大值，不包括边界</param>
        /// <returns>取随机数</returns>
        public int GetRandomNumber(int min, int max)
        {
            //每次全新的id，全球唯一
            Guid guid = new Guid();
            string guidstr = guid.ToString();
            int seed = DateTime.Now.Millisecond;
            //保证sed在同一时刻 是不相同的
            for (int i = 0; i < guidstr.Length; i++)
            {
                switch (guidstr[i])
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        seed += 1;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                        seed += 2;
                        break;
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                        seed += 3;
                        break;
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        seed += 3;
                        break;
                    default:
                        seed += 4;
                        break;
                }
            }
            Random random = new Random(seed);
            int randomNum = random.Next(min, max);
            return randomNum;
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min">最小值，包括边界</param>
        /// <param name="max">最大值，不包括边界</param>
        /// <returns>取随机数</returns>
        public int GetRandomNumberDelay(int min, int max)
        {
            //随即休息一下，再次避免产生相同的随机数
            Thread.Sleep(GetRandomNumber(500, 1000));
            //Task.Delay(500);
            return GetRandomNumber(min, max);
        }
    }
}
