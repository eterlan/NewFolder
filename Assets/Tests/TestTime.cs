using System;
using System.Collections;
using System.Collections.Generic;
using ECS.Features;
using ECS.Utility;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Time = ECS.Features.Time;

public class NewTestScript
{
    private Contexts m_contexts;

    [SetUp]
    public void Setup()
    {
        m_contexts = Contexts.sharedInstance;
    }

    [UnityTest]
    public IEnumerator TestTimerMultipleTimeFeature()
    {
        yield return new MonoBehaviourTest<TestTimeMono>();
    }
    
    
    public class TestTimeMono : MonoBehaviour, IMonoBehaviourTest
    {
        private Contexts m_ctx;
        private Time     m_feature;
        private bool     isDone;
        private IEnumerator Start()
        { 
            m_ctx = Contexts.sharedInstance;
            m_feature = new Time(m_ctx);
            m_feature.Initialize();
            
            var timerEntity = m_ctx.input.CreateEntity();
            CyLog.Log(Util.elapsedTime);

            var num = 1;
            timerEntity.AddTimer(Util.elapsedTime, 3, 0, 0.1f, () =>
            { 
                CyLog.Log(Util.elapsedTime);
                num++;
            });
            yield return new WaitForSeconds(0.5f);
            
            Assert.IsTrue(num == 4);
            
            isDone = true;
        }

        private void Update()
        {
            m_feature.Execute();
            m_feature.Cleanup();
        }

        public bool IsTestFinished => isDone;
    }
}
