/**************************************************
beginning of licensing agreement
Microsoft Public License (Ms-PL)

This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.

1. Definitions

The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.

A "contribution" is the original software, or any additions or changes to the software.

A "contributor" is any person that distributes its contribution under this license.

"Licensed patents" are a contributor's patent claims that read directly on its contribution.

2. Grant of Rights

(A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.

(B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.

3. Conditions and Limitations

(A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.

(B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.

(C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.

(D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.

(E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement. 
end of licensing agreement
**************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

public enum TraceTab
{ 
    SQL=0,
    AnalysisService=1
}

public enum DefaultTemplate
{ 
    sqldefault2000=0,
    sqldefault=1,
    sqldefault2008=2,
    asdefault=3,
    as_default_2008=4
    //asconnectivity=4,
    //asperformance=5
}
    public enum SQLVersion
    {
        sql70=0,
        sql2000=1,
        sql2005=2,
        sql2008=3

    }
    public enum Platform
    { 
        x86,
        x64,
        ia64
    }
    public class PlatVersionTracker
    {
        public  bool m_VersionTabInitialized=false;
        public bool DefaultTemplateIndexInitialized = false;

        public bool TemplateClicked = false;
        public int DefaultTemplateIndex = (int) DefaultTemplate.sqldefault2008; //sql 2008 xml template
        public int PreviousTemplateIndex = 0;

        public int DefaultVersionTabIndex = (int) SQLVersion.sql2008; //sql 2008
        public int DefaultTraceTabIndex = (int) TraceTab.SQL;
        private TabControl m_Platform;
        private TabControl m_Version;
        private TabControl m_Trace;
        private ListBox m_Cfgs;


        public int TemplateIndex
        {
            get
            {
                if (DefaultTemplateIndexInitialized == false)
                {
                    DefaultTemplateIndexInitialized = true;
                    return DefaultTemplateIndex;
                }
                else
                {
                    return PreviousTemplateIndex;
                }

            }
        }
        public PlatVersionTracker(TabControl tcPlatform, TabControl tcVersion, TabControl tcTrace, ListBox lbCfgs)
        {
            m_Platform = tcPlatform;
            m_Version = tcVersion;
            m_Trace = tcTrace;
            m_Cfgs = lbCfgs;

        }
        public void OnDefaultTemplateChanged()
        {
            
            return; //currently do nothing


        }
        public void OnTraceTabChanged()
        {
            int TemplateToSelect = 0;


            if (m_Trace.SelectedIndex == 1) //if choosing AS trace
            {
                if (m_Version.SelectedIndex == (int)SQLVersion.sql2008) //2008
                    TemplateToSelect = (int)DefaultTemplate.as_default_2008;
                else
                    TemplateToSelect = (int)DefaultTemplate.asdefault;

            }
            else
            {
                if (m_Version.SelectedIndex == (int)SQLVersion.sql2008) //2008
                {
                    TemplateToSelect = (int)DefaultTemplate.sqldefault2008;

                }
                else //2005 and below
                {
                    TemplateToSelect = (int)DefaultTemplate.sqldefault;
                }

            }

            m_Cfgs.SelectedIndex = TemplateToSelect;

        }



        public void OnVersionChanged()
        {
            if (TemplateClicked == true) //if this is a human click, do nothing and let template drive everything
            {
                TemplateClicked = false;
                return;
            }
            if (m_Trace.SelectedIndex == (int) TraceTab.AnalysisService) //as trace selected
            {
                return; //do nothing
            }
            else //if sql trace selected, it means sql needs, pssdiag
            {
                int template = 0;

                if (m_Version.SelectedIndex == (int) SQLVersion.sql2008) //sql 2008
                {
                    template  = (int)DefaultTemplate.sqldefault2008;
                }
                else if (m_Version.SelectedIndex == (int) SQLVersion.sql2005 )
                {
                    template = (int)DefaultTemplate.sqldefault; //2005 and below;
                }
                else if (m_Version.SelectedIndex == (int)SQLVersion.sql2000)
                {
                    template = (int)DefaultTemplate.sqldefault2000;

                }

                m_Cfgs.SelectedIndex = template;
            }

        }
        


        public SQLVersion DefaultSqlVersion
        {
            get
            {
                return SQLVersion.sql2008;
            }
        }
        public Platform DefaultPlatform
        {
            get
            {
                return Platform.x86;
            }
        }
        public SQLVersion SelectedSqlVersion
        {
            get {
                SQLVersion ver = SQLVersion.sql2005;
                if (m_Version.SelectedTab.Name.ToLower() == "tp2k")
                    ver = SQLVersion.sql2000;
                else if (m_Version.SelectedTab.Name.ToLower() == "tp2k5")
                    ver = SQLVersion.sql2005;
                else if (m_Version.SelectedTab.Name.ToLower() == "tp2k8")
                    ver = SQLVersion.sql2008;
                return ver;
            }

        }
        public Platform SelectedPlatform
        {

            get
                {
                    Platform plat = Platform.x86;
                    if (m_Platform.SelectedTab.Name.ToLower() == "tp32")
                    {
                        plat = Platform.x86;
                    }
                    else if (m_Platform.SelectedTab.Name.ToLower() == "tpx64")
                    {
                        plat = Platform.x64;
                    }
                    else if (m_Platform.SelectedTab.Name.ToLower() == "tpia64")
                    {
                        plat = Platform.ia64;
                    }
                   return plat;
                   
            }
        }
        public int DefaultSqlTemplate
        {
            get
            {

                int index = 0;
                if (m_Trace.SelectedIndex == 1) //AStrace
                {
                    index = (int) DefaultTemplate.asdefault;
                }
                /*
                if (SelectedSqlVersion == SQLVersion.sql2008)
                {

                    index = 1;
                }*/

                return index;


            }

        }


    }

