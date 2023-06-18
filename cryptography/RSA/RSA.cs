
using System;

/*
     p, q의 조건
     p-1 과 q-1 은 큰 소인수를 갖는다.
     p-1 과 q-1의 최대 공약수는 작은 수 이다.
     d는 n과 거의 같은 크기이다.

 ** n 구하기 **
    임의 두 소수 p와 q를 정하고 n = p * q를 해주면 n을 구할 수 있다.

 ** e 구하기 **
     Φ(n) = (p - 1) * (q - 1)식을 이용하여 Φ(n)을 구한다.
    e는 1 < e < Φ(n)로써 1과 Φ(n) 사이에 있고 Φ(n)와 서로소인 e를 정해주면 된다.
    이러한 e는 공개키에 이용이 될 것이다.
    ※ 서로소란 1 이외에 공약수를 가지지 않는 수를 의미한다.

 ** d 구하기 **
    (e * d) mod Φ(n) = 1
    즉, e*d를 Φ(n)으로 나누었을 때 나머지가 1인 d를 구하면 된다. 이때 d는 개인키에 사용될 숫자이다. 
    이제 공개키에 이용될 (n, e)와 개인키에 이용될 (n, d)를 모두 구하였다. 즉, 개인키와 공개키가 생성되었다.


    RSA 알고리즘 예시
    공개키 n, d // 개인키 n, e를 구하자

    1.두 소수 p=17과 q=11을 선택한다.

    2.N=P*Q=17*11=187을 계산한다.

    3. Φ(N)=(p-1)(q-)=16*10=160을 계산한다.

    4. 공개키 구하기 -> Φ(N)=160보다 작으면서 Φ(N)과 서로수인 수 e를 선택한다. 여기서는 e=7을 선택한다.

    5. 개인키 구하기 -> d <160 이면서 d*e mod 160=1 인 수 d를 결정한다. e=7 이므로 d*7 mod 160=1

    d=(1+160)/7 하면, d=23이다. 

    6. 결과로 얻어지는 공개키={187, 7}, 개인키={187, 23}이다.
    
    평문이 88이라고 가정하면

    암호화 숫자는 88^7 mod 187 = 11이다.

    다시 복호화하면 11^23 mod 187 = 88이다.
     */


namespace ConsoleApp1.algo.crypto
{
    public class RSA
    {
        public static double gcd(double a, double h)
        {
            double temp;
            while (true)
            {
                temp = a % h;
                if (temp == 0) { return h; }
                a = h;
                h = temp;
            }
        }

        public static void Main(string[] args)
        {   
            // public key <n, e>
            // private key <n, d>

            // 두 소수 p, q를 준비한다.
            double p = 3;
            double q = 7;
            
            // public key
            double n = p * q;

            // public key
            // p - 1, q - 1과 각각 서로소인 정수 e를 준비한다.
            double e = 2;

            // Φ(n) 를 구한다.
            double phi = (p - 1) * (q - 1);
            // 공개키 <21, 2>
            while(e < phi)
            {
                if (gcd(e, phi) == 1) break;
                else e++;
            }

            int k = 2;

            // private key
            // e * d (mod Φ(n)) = 1
            double d = (1 + (k * phi)) / e;

            double msg = 12;
            Console.WriteLine("Message data = "
                          + String.Format("{0:F6}", msg));

            // Encryption c = (msg ^ e) % n
            double c = Math.Pow(msg, e);
            c = c % n;
            Console.WriteLine("Encrypted data = "
                              + String.Format("{0:F6}", c));

            // Decryption m = (c ^ d) % n
            double m = Math.Pow(c, d);
            m = m % n;
            Console.WriteLine("Original Message Sent = "
                              + String.Format("{0:F6}", m));
        }
    }
}
