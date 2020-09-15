using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_2
{
    public class WorkEvent
    {
        /// <summary>
        /// 鱼漂集合
        /// </summary>
        public event Action Observers ;

        /// <summary>
        /// 鱼漂动了
        /// </summary>
        public void CallAllObservers()
        {
            Observers.Invoke();
        }

        /// <summary>
        /// 添加鱼漂
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(Action observer)
        {
            Observers += observer;
        }

        /// <summary>
        /// 移除鱼漂
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(Action observer)
        {
            Observers -= observer;
        }

        /// <summary>
        /// 钓鱼
        /// </summary>
        public void GetUpAction()
        {
            CallAllObservers();
        }
    }
}
