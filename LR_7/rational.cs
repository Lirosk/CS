using System;

namespace LR_7
{
    //rational number
    class RatNum: IEquatable<RatNum>
    {
        public int Up { get; private set; }

        private int down;
        public int Down
        {
            get
            {
                return down;
            }
            private set
            {
                if (value > 0)
                {
                    down = value;
                }
                else if (value == 0)
                {
                    throw new Exception("No zero in denominator.");
                }
                else
                {
                    down = -value;
                    Up *= -1;
                }
            }
        }

        public RatNum(int Up = 1, int Down = 1)
        {
            this.Up = Up;
            this.Down = Down;
        }



        //////////////////////////////////////////////////////////////////////////////////
        #region operator <

        public static bool operator <(RatNum num1, RatNum num2)
        {
            return (num1.Up * num2.Down < num2.Up * num1.Down);
        }

        public static bool operator <(RatNum num1, double num2)
        {
            return ((double)num1.Up < num2 * num1.Down);
        }

        #endregion operator <


        //////////////////////////////////////////////////////////////////////////////////
        #region operator <=

        public static bool operator <=(RatNum num1, RatNum num2)
        {
            return (num1.Up * num2.Down <= num2.Up * num1.Down);
        }

        public static bool operator <=(RatNum num1, double num2)
        {
            return ((double)num1.Up <= num2 * num1.Down);
        }

        #endregion operator <=


        //////////////////////////////////////////////////////////////////////////////////
        #region operator >

        public static bool operator >(RatNum num1, RatNum num2)
        {
            return (num1.Up * num2.Down > num2.Up * num1.Down);
        }

        public static bool operator >(RatNum num1, double num2)
        {
            return ((double)num1.Up > num2 * num1.Down);
        }

        #endregion operator >


        //////////////////////////////////////////////////////////////////////////////////
        #region operator >=

        public static bool operator >=(RatNum num1, RatNum num2)
        {
            return (num1.Up * num2.Down >= num2.Up * num1.Down);
        }

        public static bool operator >=(RatNum num1, double num2)
        {
            return ((double)num1.Up >= num2 * num1.Down);
        }

        #endregion operator >=


        //////////////////////////////////////////////////////////////////////////////////
        #region operator ==

        public static bool operator ==(RatNum num1, RatNum num2)
        {
            return (num1.Up * num2.Down == num2.Up * num1.Down);
        }

        public static bool operator ==(RatNum num1, double num2)
        {
            return ((double)num1.Up == num2 * num1.Down);
        }

        #endregion operator ==


        //////////////////////////////////////////////////////////////////////////////////
        #region operator !=

        public static bool operator !=(RatNum num1, RatNum num2)
        {
            return (num1.Up * num2.Down != num2.Up * num1.Down);
        }

        public static bool operator !=(RatNum num1, double num2)
        {
            return ((double)num1.Up != num2 * num1.Down);
        }

        #endregion operator !=

        //////////////////////////////////////////////////////////////////////////////////
        #region Equals

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            RatNum num = obj as RatNum;

            if (num == null)
            {
                return false;
            }
            
            return ((Up == num.Up) && (Down == num.Down));
        }

        public bool Equals(RatNum num)
        {
            return ((Up == num.Up) && (Down == num.Down));
        }

        public static bool Equals(RatNum num1, RatNum num2)
        {
            return ((num1.Up == num2.Up) && (num1.Down == num2.Down)) ;
        }

        public static bool Equals (RatNum num, int a)
        {
            num.reduce();

            return (num.Down == 1 && num.Up == a) ;
        }

        /*
        public bool Equals (int a)
        {
            reduce();

            return (Down == 1 && Up == a) ;
        }
        */

        public static bool Equals(RatNum num, double a)
        {
            return ((double)num.Up / num.Down == a) ;
        }

        /*
        public bool Equals(double a)
        {
            return ((double)Up / Down == a) ;
        }
        */

        #endregion


        //////////////////////////////////////////////////////////////////////////////////
        #region sum

        public static RatNum operator +(RatNum num1, RatNum num2)
        {
            var a = new RatNum(num1.Up * num2.Down + num2.Up * num1.Down, num1.Down * num2.Down);
            a.reduce();
            return a;
        }

        public static RatNum operator +(RatNum num1, int num2)
        {
            var a = new RatNum(num1.Up + num2 * num1.Down, num1.Down);
            a.reduce();
            return a;
        }

        public static RatNum operator +(RatNum num1, double num2)
        {
            var a = new RatNum((int)(10000 * (num1.Up + num2 * num1.Down)), num1.Down * 10000);
            a.reduce();
            return a;
        }

        public static RatNum operator ++(RatNum num1)
        {
            return new RatNum(num1.Up + num1.Down, num1.Down);
        }

        #endregion sum


        //////////////////////////////////////////////////////////////////////////////////
        #region difference

        public static RatNum operator -(RatNum num1, RatNum num2)
        {
            var a = new RatNum(num1.Up * num2.Down - num2.Up * num1.Down, num1.Down * num2.Down);
            a.reduce();
            return a;
        }

        public static RatNum operator -(RatNum num1, int num2)
        {
            var a = new RatNum((num1.Up - num2 * num1.Down), num1.Down);
            a.reduce();
            return a;
        }

        public static RatNum operator -(RatNum num1, double num2)
        {
            var a = new RatNum((int)(10000 * (num1.Up - num2 * num1.Down)), num1.Down * 10000);
            a.reduce();
            return a;
        }

        public static RatNum operator --(RatNum num1)
        {
            return new RatNum(num1.Up - num1.Down, num1.Down);
        }

        public static RatNum operator -(RatNum num1)
        {
            return new RatNum(-num1.Up, num1.Down);
        }

        #endregion difference


        //////////////////////////////////////////////////////////////////////////////////
        #region multiplication

        public static RatNum operator *(RatNum num1, RatNum num2)
        {
            var a = new RatNum(num1.Up * num2.Up, num1.Down * num2.Down);
            a.reduce();
            return a;
        }

        public static RatNum operator *(RatNum num1, int num2)
        {
            var a = new RatNum(num2 * num1.Up, num1.Down);
            a.reduce();
            return a;
        }

        public static RatNum operator *(RatNum num1, double num2)
        {
            var a = new RatNum((int)(num2 * 10000 * num1.Up), num1.Down*10000);
            a.reduce();
            return a;
        }

        #endregion multiplication


        //////////////////////////////////////////////////////////////////////////////////
        #region division


        public static RatNum operator /(RatNum num1, RatNum num2)
        {
            var a = new RatNum(num1.Up * num2.Down, num1.Down * num2.Up);
            a.reduce();
            return a;
        }        
        public static RatNum operator /(RatNum num1, int num2)
        {
            RatNum a = new RatNum();
            if (num2 > 0)
            {
                a = new RatNum(num1.Up, (num1.Down * num2));
            }
            else if (num2 < 0)
            {
                a = new RatNum(-num1.Up, (num1.Down * num2));
            }
            else
            {
                throw new Exception("No divide by zero.");
            }

            a.reduce();
            return a;
        }

        public static RatNum operator /(RatNum num1, double num2)
        {
            RatNum a = new RatNum();
            if (num2 > 0)
            {
                a = new RatNum(num1.Up * 10000, (int)(10000 * (num1.Down * num2)));
            }
            else if (num2 < 0)
            {
                a = new RatNum(-num1.Up * 10000, (int)(10000 * (num1.Down * num2)));
            }
            else
            {
                throw new Exception("No division by zero.");
            }

            a.reduce();
            return a;
        }

        #endregion division


        //////////////////////////////////////////////////////////////////////////////////       
        #region Simplifying fraction

        public void reduce() 
        {
            int a = Down;
            if (Math.Abs(Up) > Down)
            {
                a = Up;
            }

            a = (int)Math.Sqrt(a);

            while ((Up % 2 == 0) && (Down % 2 == 0))
            {
                Up /= 2;
                Down /= 2;
            }

            for (int i = 3; i < a; i += 2)
            {
                while ((Up % i == 0) && (Down % i == 0))
                {
                    Up /= i;
                    Down /= i;
                }
            }
        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////
        #region ToString

        public override string ToString()
        {
            return $"{(double)Up / (double)Down}";
        }

        public string NormToString()
        {
            if (Up == 0)
            {
                return "0";
            }
            if (Down == 1)
            {
                return $"{Up}";
            }
            return $"{Up}/{Down}";
        }

        public string DecToString()
        {
            if (Up == 0)
            {
                return "0";
            }
            if (Down == 1)
            {
                return $"{Up}";
            }
            return ((double)Up / (double)Down).ToString();
        }

        #endregion ToString


        //////////////////////////////////////////////////////////////////////////////////
        #region Get from others types

        public static RatNum ToRatNum(string str)
        {
            int Up = 0, Down = 1;
            bool minus = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    Up *= 10;
                    Up += str[i] - 48;
                }
                else if (str[i] == '/') // '/'
                {
                    Down = 0;

                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if (str[j] >= '0' && str[j] <= '9')
                        {
                            Down *= 10;
                            Down += str[j] - '0';
                        }
                    }

                    break;
                }
                else if (str[i] == '.' || str[i] == ',') // '.' ','
                {
                    Down = 1;

                    for (int j = i + 1; j < str.Length; j++)
                    {
                        Up *= 10;
                        Up += str[j] - 48;
                        Down *= 10;
                    }

                    break;
                }
                else if (str[i] == '-')
                {
                    minus = true;
                }
            }

            RatNum a = new RatNum(Up * ((minus) ? (-1) : (1)), Down);
            a.reduce();
            return a;
        }
        public static RatNum ToRatNum(int num2)
        {
            return new RatNum(num2, 1);
        }

        public static RatNum ToRatNum(double num2)
        {
            var a = new RatNum((int)(num2 * 10000), (int)Math.Pow(10, (int)Math.Log10((int)num2) + 4));
            a.reduce();
            return a;
        }

        #endregion Get from others types


        //////////////////////////////////////////////////////////////////////////////////
        #region To double or int

        public static double ToDouble(RatNum num)
        {
            if (num.Down == 1)
            {
                return num.Up;
            }
            return (double)num.Up / num.Down;
        }

        public double ToDouble()
        {
            if (Down == 1)
            {
                return Up;
            }
            return (double)Up / Down;
        }

        public static int ToInt(RatNum num)
        {
            if (num.Down == 1)
            {
                return num.Up;
            }
            return num.Up / num.Down;
        }

        public int ToInt()
        {
            if (Down == 1)
            {
                return Up;
            }
            return Up / Down;
        }

        #endregion To double or int


        //////////////////////////////////////////////////////////////////////////////////
        #region type conversion

        public static implicit operator RatNum(int x)
        {
            return new RatNum(x, 1);
        }

        public static implicit operator RatNum(double x)
        {
            var a = new RatNum((int)(x * 10000), 10000);
            a.reduce();
            return a;
        }

        public static explicit operator int(RatNum num)
        {
           return num.Up / num.Down;
        }

        public static explicit operator double(RatNum num)
        {
            return (double)num.Up / num.Down;
        }

        #endregion type conversion
    }
}
