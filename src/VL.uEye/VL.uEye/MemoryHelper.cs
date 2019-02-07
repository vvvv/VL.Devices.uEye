using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VL.uEyeCam
{
    public static class MemoryHelper
    {
        public static uEye.Defines.Status AllocImageMems(uEye.Camera Camera, int nCount)
        {
            uEye.Defines.Status statusRet = uEye.Defines.Status.SUCCESS;

            for (int i = 0; i < nCount; i++)
            {
                statusRet = Camera.Memory.Allocate();

                if (statusRet != uEye.Defines.Status.SUCCESS)
                {
                    FreeImageMems(Camera);
                }
            }

            return statusRet;
        }

        public static uEye.Defines.Status FreeImageMems(uEye.Camera Camera)
        {
            int[] idList;
            uEye.Defines.Status statusRet = Camera.Memory.GetList(out idList);

            if (uEye.Defines.Status.SUCCESS == statusRet)
            {
                foreach (int nMemID in idList)
                {
                    do
                    {
                        statusRet = Camera.Memory.Free(nMemID);

                        if (uEye.Defines.Status.SEQ_BUFFER_IS_LOCKED == statusRet)
                        {
                            Thread.Sleep(1);
                            continue;
                        }

                        break;
                    }
                    while (true);
                }
            }

            return statusRet;
        }

        public static uEye.Defines.Status InitSequence(uEye.Camera Camera)
        {
            int[] idList;
            uEye.Defines.Status statusRet = Camera.Memory.GetList(out idList);

            if (uEye.Defines.Status.SUCCESS == statusRet)
            {
                statusRet = Camera.Memory.Sequence.Add(idList);

                if (uEye.Defines.Status.SUCCESS != statusRet)
                {
                    ClearSequence(Camera);
                }
            }

            return statusRet;
        }

        public static uEye.Defines.Status ClearSequence(uEye.Camera Camera)
        {
            return Camera.Memory.Sequence.Clear();
        }
    }
}
