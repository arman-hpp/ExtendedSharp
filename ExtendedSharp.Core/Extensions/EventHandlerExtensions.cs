using System;

namespace ExtendedSharp.Core.Extensions
{
    public static class EventHandlerExtensions
    {
        /// <summary>
        /// Method for invoking/raising events.
        /// </summary>
        /// <param name="handler">Required. The EventHandler to Invoke.</param>
        /// <param name="sender">Required.</param>
        public static void Raise(this EventHandler handler, object sender)
        {
            handler.Raise(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Method for invoking/raising events.
        /// </summary>
        /// <param name="handler">Required. The EventHandler to Invoke.</param>
        /// <param name="sender">Required.</param>
        /// <param name="e">Required.</param>
        public static void Raise(this EventHandler handler, object sender, EventArgs e)
        {
            if (handler != null)
                handler(sender, e);
        }

        /// <summary>
        /// Method for invoking/raising events.
        /// </summary>
        /// <param name="handler">Required. The EventHandler to Invoke.</param>
        /// <param name="sender">Required.</param>
        public static void Raise<TEventArgs>(this EventHandler<TEventArgs> handler, object sender) where TEventArgs : EventArgs
        {
            handler.Raise(sender, Activator.CreateInstance<TEventArgs>());
        }

        /// <summary>
        /// Method for invoking/raising events.
        /// </summary>
        /// <param name="handler">Required. The EventHandler to Invoke.</param>
        /// <param name="sender">Required.</param>
        /// <param name="e">Required.</param>
        public static void Raise<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs e) where TEventArgs : EventArgs
        {
            if (handler != null)
                handler(sender, e);
        }

    }
}
