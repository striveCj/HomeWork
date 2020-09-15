using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_2
{
    public class Work
    {
        /// <summary>
        /// 鱼漂集合
        /// </summary>
        public List<IBaseInterface> Observers=new List<IBaseInterface>();

        /// <summary>
        /// 鱼漂动了
        /// </summary>
        public void CallAllObservers()
        {
            foreach (var item in Observers)
            {
                item.GetUp();
            }
        }

        /// <summary>
        /// 添加鱼漂
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(IBaseInterface observer)
        {
            Observers.Add(observer);
        }

        /// <summary>
        /// 移除鱼漂
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(IBaseInterface observer)
        {
            Observers.Remove(observer);
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
