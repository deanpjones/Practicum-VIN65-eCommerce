using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicorEagle.Model
{
    //DEAN JONES
    //JUL.11, 2017
    //CLASS TO BUILD CSV (FLAT OR FIXED WIDTH FILE)
    //create a flat file (in Epicor's format)
    //FLAT FILE (PARENT FILE)(header and detail class supporting)
    //combines info from (csv header) and makes a list of (csv details) to make one csv object

    //SUPPORTING FILES 
    //Model/EpicorCsvHeader.cs (header format)
    //Model/EpicorCsvDetail.cs (detail format)


    public class EpicorCsv
    {
        //PROPERTIES
        private EpicorCsvHeader csvHeader;
        private List<EpicorCsvDetail> csvDetails;

        //GETTERS AND SETTERS
        internal EpicorCsvHeader CsvHeader { get => csvHeader; set => csvHeader = value; }
        internal List<EpicorCsvDetail> CsvDetails { get => csvDetails; set => csvDetails = value; }

        //CONSTRUCTOR 
        public EpicorCsv()
        {
            this.CsvHeader = new EpicorCsvHeader();                 //need to INSTANTIATE the (EpicorCsvHeader) object here
            this.CsvDetails = new List<EpicorCsvDetail>();          //need to INSTANTIATE the list here            
        }

        //TOSTRING

    }
}
