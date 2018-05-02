using Newtonsoft.Json.Linq;
using ReactNative.UIManager.Events;

namespace ReactNative.Views.TextInput
{
    class ReactTextInputCancelEditingEvent : Event
    {
        private readonly string _text;

        public ReactTextInputCancelEditingEvent(int viewTag, string text)
            : base(viewTag)
        {
            _text = text;
        }

        public override string EventName
        {
            get
            {
                return "topCancelEditing";
            }
        }

        public override bool CanCoalesce
        {
            get
            {
                return false;
            }
        }

        public override void Dispatch(RCTEventEmitter eventEmitter)
        {
            var eventData = new JObject
            {
                { "target", ViewTag },
                { "text", _text },
            };

            eventEmitter.receiveEvent(ViewTag, EventName, eventData);
        }
    }
}
