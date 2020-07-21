using System;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //不同的鱼漂调不同的鱼
            //钓鱼者，看到鱼漂动了，开始钓鱼
            //钓鱼者(观察者)看到鱼漂动了(满足条件，发布动作)钓鱼(订阅动作执行动作)

            EventMethod();
        }

        /// <summary>
        /// 对象的方式添加观察者
        /// </summary>
        public static void ObjectMethod()
        {
            Work work=new Work();
            var say = new Say();
            //添加不同的鱼漂
            work.AddObserver(say);
            work.AddObserver(new SayWork());
            work.RemoveObserver(say);
            //钓鱼
            work.GetUpAction();
        }

        /// <summary>
        /// 使用委托的方式添加观察者
        /// </summary>
        public static void ActionMethod()
        {
            WorkAction workAction=new WorkAction();
            var say=new Say();
            workAction.AddObserver(say.GetUp);
            workAction.AddObserver(new SayWork().GetUp);
            workAction.RemoveObserver(say.GetUp);
            workAction.Observers.Invoke();
            workAction.GetUpAction();
        }

        /// <summary>
        /// 使用事件的方式添加观察者
        /// </summary>
        public static void EventMethod()
        {
            WorkEvent workAction = new WorkEvent();
            var say = new Say();
            workAction.AddObserver(say.GetUp);
            workAction.AddObserver(new SayWork().GetUp);
            workAction.RemoveObserver(say.GetUp);

            workAction.GetUpAction();
        }
    }
}
