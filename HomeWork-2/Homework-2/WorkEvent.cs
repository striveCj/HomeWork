using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_2
{
    public class WorkEvent
    {
        /// <summary>
        /// 待通知对象继承的接口集合
        /// </summary>
        public event Action Observers ;

        /// <summary>
        /// 通知所有观察者
        /// </summary>
        public void CallAllObservers()
        {
            Observers.Invoke();
        }

        /// <summary>
        /// 添加观察者
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(Action observer)
        {
            Observers += observer;
        }

        /// <summary>
        /// 移除观察者
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(Action observer)
        {
            Observers -= observer;
        }

        /// <summary>
        /// 通知所有观察者要执行动作
        /// </summary>
        public void GetUpAction()
        {
            CallAllObservers();
        }
    }
}
