﻿/*
 * Copyright (C) 2009-2011 Ferreri Alessio
 * Copyright (C) 2009-2018 PCSX2 Dev Team
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace GSDumpGUI
{
    [Serializable]
    public class GIFRegUV : GIFReg
    {
        public double U;
        public double V;

        public GIFRegUV(byte addr, UInt64 LowData, UInt64 HighData, bool PackedFormat) : base(addr, LowData, HighData, PackedFormat) { }

        static public GIFReg Unpack(GIFTag tag, byte addr, UInt64 LowData, UInt64 HighData, bool PackedFormat)
        {
            GIFRegUV uv = new GIFRegUV(addr, LowData, HighData, PackedFormat);
            uv.Descriptor = (GIFRegDescriptor)addr;
            if (PackedFormat)
            {
                uv.U = GetBit(LowData, 0, 14) / 16d;
                uv.V = GetBit(LowData, 32, 14) / 16d;
            }
            else
            {
                uv.U = GetBit(LowData, 0, 14) / 16d;
                uv.V = GetBit(LowData, 16, 14) / 16d;
            }
            return uv;
        }

        public override string ToString()
        {
            return Descriptor.ToString() + "@U : " + U.ToString("F4") + "@V : " + V.ToString("F4");
        }
    }
}
