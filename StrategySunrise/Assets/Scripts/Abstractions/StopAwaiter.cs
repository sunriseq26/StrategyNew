﻿using Utils;

namespace Abstractions
{
    public class StopAwaiter : AwaitableBase<AsyncExtensions.Void>
    {
        private readonly UnitMovementStop _unitMovementStop;

        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStop = unitMovementStop;
            _unitMovementStop.OnStop += onStop;
        }

        private void onStop()
        {
            _unitMovementStop.OnStop -= onStop;
            onWaitFinish(new AsyncExtensions.Void());
        }
    }
}