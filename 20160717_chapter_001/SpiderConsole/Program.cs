using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpiderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 写一个简单的网络爬虫
             * 思路:
             * 1.选定一个目标,对目标进行分析,模拟Web请求并下载页面 (今天先试试这一步吧.)
             *      我以前找工作就是到智联或者51job,直接用爬虫抓取他们的职位数据,然后分析筛选的.
             *      现在,我再一次试着去抓取一下智联的数据,怎么样?
             *      你们可以在聊天窗口-->右侧的,跟我互动聊天.
             * 2.分析页面代码,用NSoup或者正则提取需要的内容
             * 3.保存到数据库或者其它存储媒介
             */


            //现在,我们打开智联的网站,去分析一下.
            /* 这样我就看到他请求服务器的方式了,我模拟一下这个请求,通过控制台把网页输出来
             * 我先用Fildder去试着请求一次,看能不能行.
             * 
             * 
             * 这样注释不行?
             * 
             * 刚刚通过工具,发现直接请求是可以的.有的网站的请求还需要很多其它东西,有点小麻烦的,现在这个还是比较简单
             * 
             * 这个网页就下载下来了
             * 看清没?
             * 爬虫是不是很简单?
             * 是的,可以同时抓取很多的.比如现在我把程序改为同时抓10个页面,并将他们保存到文件里.
             * 可以随便设置参数呀
             * 
             */

            var list = new List<string>();
            for (int i = 1; i < 10; i++)
            {
                //这些以后会教你们,现在我简单说一下
                //这些参数,你们注意观察
                /*
                 * jl=成都
                 * &sm=0
                 * &sg=c29e130612a64c19aaecc1d40effbd1a
                 * &p=2
                 * 
                 * 发现这些参数都是成对的.左边是参数名,如jl,sm,sg,p
                 * 我通过在网页上观察,发现p代表的是第几页,你们现在跟我一起去看看.   嗯.可以说是,request.querystring[jl]等等,你说的是服务器端的处理方法
                 * 现在我做的事情是模拟人工去访问网站.就相当于我现在写的程序是客户端.不是服务器端
                 * 明白?
                 * 现在我们去观察一下网站
                 * 看到了没?
                 * 直接执行了
                 * 是啊.
                 * 下载下来以后就可以任你施展了,你想要什么内容,自己去折腾就行了.
                 * 今天先这样了.我去休息一下.
                 * 晚上还要给我家崽做点心吃呢.
                 * 明天等通知,我估计下午三点左右会出通知具体什么时候讲课.
                 * 可以给.这个内容我会上传到GitHub.到时你可以下载
                 * 但这个要等一下,因为我现在需要休息了.
                 * 周末愉快
                 */
                list.Add(string.Format("http://sou.zhaopin.com/jobs/searchresult.ashx?jl=成都&sm=0&sg=c29e130612a64c19aaecc1d40effbd1a&p={0}",i));

            }

            foreach (var url in list)
            {
                var content = DonwloadPage(url);
                var fileName = string.Format(@"D:\zhilian\{0}.txt", Guid.NewGuid());
                SaveDocuemntToFile(fileName,content);
            }

            //string url = "http://sou.zhaopin.com/jobs/searchresult.ashx?jl=长沙+株洲+湘潭&sm=0&sg=c29e130612a64c19aaecc1d40effbd1a&p=2 ";
            //var content = DonwloadPage(url);

            //输出到控制台
            Console.WriteLine("完成");

        }

        private static string DonwloadPage(string url)
        {
            Console.WriteLine("正在下载URL:{0}",url);
            //创建一个Web Http请求
            var request = WebRequest.CreateHttp(url);

            //得到响应
            var response = request.GetResponse();

            //通过响应得到输出流
            var stream = response.GetResponseStream();

            //创建流读取器
            StreamReader sr = new StreamReader(stream);

            //从流读取内容
            var content = sr.ReadToEnd();
            return content;
        }


        static void SaveDocuemntToFile(string path, string content)
        {
            Console.WriteLine("正在保存到路径:{0}",path);
            if (!File.Exists(path))
            {
                using (var stream = File.Create(path))
                {
                    stream.Flush();
                }
            }
            using (FileStream fs = new FileStream(path,FileMode.Create,FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(content);
                }
            }
        }
    }
}
