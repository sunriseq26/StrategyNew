using UserControlSystem.UI.Model;
using Utils;

namespace UserControlSystem.UI.Model
{
    public class NewValueNotifier<TAwaited> : AwaitableBase<TAwaited>
    {
        private readonly ScriptableObjectValueBase<TAwaited> _scriptableObjectValueBase;

        public NewValueNotifier(ScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += onNewValue;
        }

        private void onNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= onNewValue;
            onWaitFinish(obj);
        }
    }
}