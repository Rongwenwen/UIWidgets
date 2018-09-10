using System;
using System.Collections.Generic;
using UIWidgets.foundation;
using UnityEngine;

namespace UIWidgets.async {
    public class MicrotaskQueue {
        private Queue<Action> _queue = new Queue<Action>();

        public void scheduleMicrotask(Action action) {
            this._queue.Enqueue(action);
        }

        public void flushMicrotasks() {
            while (this._queue.isNotEmpty()) {
                var action = this._queue.Dequeue();
                try {
                    action();
                }
                catch (Exception ex) {
                    Debug.LogError("Error to execute microtask: " + ex);
                }
            }
        }
    }
}