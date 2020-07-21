using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_2
{
    public class Work
    {
        /// <summary>
        /// 待通知对象继承的接口集合
        /// </summary>
        public List<IBaseInterface> Observers=new List<IBaseInterface>();

        /// <summary>
        /// 通知所有观察者
        /// </summary>
        public void CallAllObservers()
        {
            foreach (var item in Observers)
            {
                item.GetUp();
            }
        }

        /// <summary>
        /// 添加观察者
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(IBaseInterface observer)
        {
            Observers.Add(observer);
        }

        /// <summary>
        /// 移除观察者
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(IBaseInterface observer)
        {
            Observers.Remove(observer);
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
