using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiteTester.Domain.Entities;

namespace SiteTester.Core.Application
{
    public class ThreadAgent
    {
        private ConcurrentQueue<Site> _inputQueue;
        private ConcurrentQueue<Result> _outputQueue;
        private int _numThread = 2;
        private Thread[] _threadList;

        public ThreadAgent(List<Site> sites)
        {
            _setQueues(sites);
        }

        public ThreadAgent(List<Site> sites, int nThread)
        {
            setNumThread(nThread);
            _setQueues(sites);
        }

        public void setNumThread(int n)
        {
            _numThread = n;
            _threadList = new Thread[_numThread];
        }

        private void _setQueues(List<Site> sites)
        {
            _inputQueue = new ConcurrentQueue<Site>();
            _outputQueue = new ConcurrentQueue<Result>();

            // fill the input queue prior to start threads
            foreach (Site site in sites)
            {
                _inputQueue.Enqueue(site);
            }
        }

        public List<Result> run()
        {
            for (var i = 0; i < _numThread; i++)
            {
                _threadList[i] = new Thread(_scanWebsite);
            }

            for (var i = 0; i < _numThread; i++)
            {
                _threadList[i].Start();
                _threadList[i].Join();
            }

            return _outputQueue.ToList();
        }

        private void _scanWebsite()
        {
            Site siteToTest;
            string url;
            string statusCode;
            while (!_inputQueue.IsEmpty)
            {
                _inputQueue.TryDequeue(out siteToTest);
                foreach(Uri uri in SiteRequest.sanitizeUrl(siteToTest.BaseUrl))
                {
                    statusCode = SiteRequest.callUrl(uri);
                    _outputQueue.Enqueue(new Result(siteToTest, uri, statusCode));
                }
            }
        }


    }
}
