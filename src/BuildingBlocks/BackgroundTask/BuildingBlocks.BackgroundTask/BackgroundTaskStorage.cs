using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.BackgroundTask
{
    public abstract class BackgroundTaskStorage<TResult>
    {
        private readonly IDictionary<Guid, Task<TResult>> _dict;
        
        public BackgroundTaskStorage()
        {
            _dict = new Dictionary<Guid, Task<TResult>>();
        }

        public Guid RegisterTask(Task<TResult> task)
        {
            var guid = Guid.NewGuid();
            _dict.Add(guid, task);

            return guid;
        }

        public bool? TaskReady(Guid guid)
        {
            var hasTask = _dict.TryGetValue(guid, out var task);

            if (!hasTask)
                return null;

            return task.Status != TaskStatus.Running;
        }

        public bool TryGetTask(Guid guid, out Task<TResult> result)
        {
            return _dict.TryGetValue(guid, out result);
        }
    }
}
