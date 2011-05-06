using System;

namespace EWSEditor.PropertyInformation
{
    internal class BinaryParser
    {
        private byte[] MyBuffer = null;
        private int Cursor = 0;

        internal BinaryParser(byte[] buffer)
        {
            this.MyBuffer = buffer;
        }

        /// <summary>
        /// Advance the position of the cursor in the buffer
        /// by count.
        /// </summary>
        /// <param name="count"></param>
        internal void Advance(int count)
        {
            if ((this.Cursor + count) < this.MyBuffer.Length)
            {
                this.Cursor = this.Cursor + count;
            }
        }
    }
}