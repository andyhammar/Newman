﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newman.Domain.ViewModels;

namespace Newman.Domain
{
    public class DataRepoLomma : IDataRepo
    {
        public Task<IEnumerable<PlaygroundIvm>> GetPlaygroundsAsync()
        {
            return Task.Factory.StartNew(() => _playgroundsData.Select(CreatePlaygroundIvm));
        }

        private PlaygroundIvm CreatePlaygroundIvm(string line)
        {
            var lineItems = line.Split(_separator);

            var geoService = new GeoService();

            var x = lineItems[2];
            var y = lineItems[3];

            return new PlaygroundIvm
                {
                    Name = lineItems[1],
                    Position = geoService.GetPosition(x, y),
                    Category = string.Empty,
                    CityPart = string.Empty,
                    Type = string.Empty
                };

        }

        private readonly char[] _separator = new[] { ';' };

        private readonly string[] _playgroundsData = new[]{
            //"OBJEKTNUMMER;KATEGORI;NAMN;TYP;STADSDEL;X;Y",
            //"NR;NAMN;X-koord;Y-koord",
            "1;PARKALLÈN;120166,6879;6176597,671",
            "2;PLANTSKOLEVÄGEN;120639,2039;6176913,526",
            "5;CARL OLSSONSVÄG;120873,9166;6176739,504",
            "7;MÅSVÄGEN;120671,7263;6177503,288",
            "8;ÖRNVÄGEN;120567,389;6177692,466",
            "9;HÖKVÄGEN;120780,6059;6177767,876",
            "10;KROKVÄGEN;120705,7071;6179024,866",
            "11;PER BORGLINS VÄG;120527,8099;6178961,211",
            "13;LEIFS VÄG;120069,4503;6178058,934",
            "16;RURIKSVÄG;120094,0238;6177790,496",
            "17;BJÄREHOVSVÄGEN;119851,4922;6177515,579",
            "18;RÅDMANSVÄGEN;119491,2612;6178563,546",
            "19;JÄRAVALLSVÄGEN;119163,6725;6178047,031",
            "20;HOLLÄNDARHUSVÄGEN;118983,2369;6178338,7",
            "21;KADETTVÄGEN;119241,1908;6178491,915",
            "24;MAJORSVÄGEN;119701,0623;6178694,256",
            "26;AGRONOMVÄGEN;119516,2914;6178230,478",
            "28;KANSLERSVÄGEN;119825,0825;6178420,193",
            "29;HOVSLAGAREVÄGEN;119525,4758;6177944,727",
            "31;STUDENTVÄGEN;119778,6733;6178101,845",
            "34;FLÄDIE MEJERIVÄGEN;123246,4054;6178225,116",
            "35;FJELIE BYAVÄG;125173,9515;6178169,197",
            "38;MÅNS OLS VÄG;123372,6158;6177969,748",
            "39;LAVENDELVÄGEN;120560,1152;6177951,52",
            "41;MELBAVÄGEN;119374,8845;6177523,974",
            "42;BENGTA RASMUS VÄG;120795,5486;6179067,711",
            "43;ANNA SÖMMERSKAS VÄG;119702,7818;6177722,001",
            "44;HULDA RASKS VÄG;121024,5335;6178901,816",
            "45;TROLLSJÖVÄGEN;118969,881;6178112,785",
            "49;TAPPERS VÄG;121928,1363;6174997,263",
            "51;INDUSTRIGATAN;123793,375;6172667,088",
            "52;LÖNNGATAN;123438,8492;6172541,147",
            "53;ASTRKANGATAN;123774,8052;6172532,943",
            "54;ALNARPSVÄGEN;124065,7116;6172086,287",
            "55;NYPONGATAN;124296,6296;6172112,387",
            "56;LINGONGATAN;124187,15;6171265,396",
            "57;BRAMSGATAN;123724,5646;6171401,668",
            "58;PILGATAN;123524,479;6171843,018",
            "59;AKACIAGATAN;123837,2457;6172268,763",
            "60;BLÅMESGATAN;123056,709;6171439,784",
            "61;PELLEDAMSVÄGEN;122805,6286;6171287,18",
            "62;BANTORGET;123120,0142;6172345,715",
            "63;STRANDVÄGEN;123044,1268;6172833,846",
            "64;GAMLA VÄGEN;124079,7991;6173920,148",
            "65;BRIGGATAN;123415,7933;6171517,784",
            "67;BETHACKEGÅNGEN;124088,3517;6172833,604",
            "68;TRUMLEGÅNGEN;124205,8632;6172849,003",
            "70;HAMMELTYGSGÅNGEN;124205,0358;6172792,899",
            "71;SKÖRDEGÅNGEN;124212,6091;6172739,871",
            "72;ALNETORGET;124088,033;6172635,186",
            "73;FAMNAMÅLSTORGET;124137,6736;6172628,628",
            "74;KAPPELANDSTORGET;124104,137;6172511,944",
            "76;SKÅLPUNDSTORGET;124227,3595;6172491,209",
            "77;LOMMA SALTSJÖBADVÄG;122638,8527;6171660,879",
            "78;STRANDÄNGSGATAN;122570,538;6172151,269",
            "79;HORNSGATAN;122463,3181;6171036,062",
            "81;KROKÅKERSGATAN;124268,4854;6173154,382",
            "82;STANVRAKSGATAN;123954,3147;6173135,34",
            "84;ENSKIFTESGATAN;124292,6856;6173014,417",
            "85;LERVIKSGATAN;124493,2657;6172996,179",
            "86;LUPINGATAN;124326,6481;6172610,478",
            "87;KAMOMILLGATAN;124392,764;6172520,3",
            "88;ENSKIFTESGATAN ?;124258,1368;6172880,085",
            "89;SVENSAGATAN;123522,6933;6173660,878",
            "90;KRYSSGRÄND;122409,9749;6172838,538",
            "91;TEGELGATAN;123543,5553;6173548,403"};
    }
}