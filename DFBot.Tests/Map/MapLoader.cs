using System.IO;
using DFBot.Map;
using NFluent;
using NUnit.Framework;

namespace DFBot.Tests.Map
{
    public class LoadMap
    {
        private const string FileName = "10297_0802221713X";
        private readonly string _fileMapFullPath = Directory.GetCurrentDirectory() + "/maps/" + $"{FileName}.txt";

        [Test]
        public void SuccessUnpacking()
        {
            var mapLoader = new MapUnpacker();
            var result = mapLoader.GetUnpackedMapData("10297", "0802221713");

            var expected = @"10297|203b3f48005c492e180537035a26250f0f304d5c740145453f4c2c4e3c59264a1e51124b1942103039574f402c08211736296b4319205d0d6f384d0b3731573e04020c01253a2a30191f24245351254f0c232f4508472719241627040f4645476f1d521e3c031e03555a5e5c1a4d1f0004284a33475e06187021223355394a174047692f2d2b14657b5e415e19580e095e5a3227335b6d216d19190e3d18315a68301c3b475b262f717a393d1b0e36050d324b4e2527142e16490b211d14105d10004b3d41095c130b3e3c341c10521e3a030f461c264f575354321f334126533b1c09323f482d556f2e1c051e0a5a2608510030495c5d08126d12450a4e38590f431e513f4219421430105e4f40010121173229424a4f1470536038490b1e38573e295c3701213a0339191f092d75512164232a2f45254e011920160e0d0f466819601d561e150a1e037853785c1e6630090428673a615e02185928223378307c17444740262d2b393b745e455e30510e0973531427377042284b1934071b18357147393a3b6a52002f225210343d0e1b0c2b324f4e0c2e322e3b400b2119143954360066344109581322372c343119521e2e05264f3a26625e755436341c48005316152f323b48045c492e310c380a5e262158263064557b0841453b4c2c4e155029431a51164b19423939265e4b17790821171f20644a1d20595a463864023838533e005537010c3325391d1f202453510c46032a2b450c4727190d1f280d0b6d4710461d7b17150a1a03515a5e5c3344360900284e33475e2f115928263351394a17694e4026292b1032525e685716510a095a5a32271a5262284f4e340e3d18185367393e3b435b262f0f5b3634390e32050d3262473a2e362e12490b21341d1f5432004f3d4109751a0437281f1e10521e030c004f3e264b5753541b163c4804533f1c09321641225c4d2e18051e0a732f07582267645c5d086c4c3b4c284e3c5959473758164b1d421030105e6649280825173629424a30297f5a42384d0b1e387e3726553301253a0339301606245751254f252a064c2a47231924160e0d264f7710424a021e150a370a775a5a5c1a4d36092d216833435e061859280b3a77394e406947402604223632565e415e305127007c5a3627335b442862103b0e3918315a41391332655b222f265210341407320509324b4e5b0a142712490f211d1439541f094f3d45095c132237053d3e1056352c05264f132f6d575754321f1a48295a191c0d323f48045c60273e051a0a5a2621580f396b5c590845453b4c05471a590b681851164b304b3630145e4f402808081e1029464a1920595a6f316b0b1a38573e00551e08033a0739191f20247a58034f212a2f450c470e1024160a0d0f46163e6014521e110a1e03515a77551a4d320904284e336e5720185d2822335139631e664744262d2b471a7b57675e34510e095a5a1b2e155b40284b191d0e1411075a45123c3b435b0f26005214343d0e3205243b6d4e082e322e124922283b143d543600181568007a1326372c3418107b170c05224f3a264b577a5d141f1e4800533f1c203b1948005c492e180537037c26255826304d5c7b0145453f4c2c4e6b0f264a1e51124b19421030395769402c08211736296b433f205d5a46384d0b3731713e04553701253a2a303f1f24245351254f0c230945084727192416270429464510461d521e3c033803555a5e5c1a4d1f0022284a33475e06187021043355394a174047692f0b2b1432525e415e195828095e5a3227335b6d216d1919253b18315a68301c3b475b262f2652393d3d0e36050d324b4e2527142e16490b211d14105d10004b3d41095c130b3e0a341c10521e2a050f461c264f575354321f334136533b4b5a323f482d556f2e1c051e0a5a2608510030495c5d08454512450a4e38590f431e513f423f421430105e4f40010107173229424a192070536038490b1e38573e295c1101213a0339191f092d7551214f252a2f45254e011920160e0d0f466819461d561e150a48067853785c1e4d36090428673a615e02335f28223378306c17444740262d2b393b745e455e30510e0973531427375b44284b1934071b18355a41393a3b6a52002f220539343d0e1b0c2b324f4e0c2e322e3b402d2119143954360066346709581322372c343119741e2e05264f3a26625e7554361f1a48005316152f323b48045c492e310c1e0a5e262158263064555d084112124c2c4e155029431a51164b19423639105e4b40280821171f20644a1d20595a463864022838533e005537010c3325391d1f202453510c46032a2b450c472719021f0e0d0b464110461d7417150a1a03515a087c3344100900284e33475e2f117f28263351394a17694e6626292b1032525e685716510a5e735a650f1a5262284f191d0e3d18185341393e3b435b262f0f5b1034390e32055a006d470c2e362e12490b213b1d395432004f3d4109751a043728341810521e030c004f3e264b5753541b163c4804533f1c09321941045c4d2e18051e0a732f215822304d5c5d086c4c3b4c284e3c590f433758304b1d421030105e66490e0825173629424a30297f5a42384d0b1e387e3726553301253a0339301620245751254f252a064c0c47231924160e0d294f4110421d521e150a380a515a5a5c1a4d6f192d216833435e061859280b3a67394e401447402604223632565e415e305128005a5a3627335b44286d101d0e3918315a16131c32435b222f265210341407140509324b4e0c2e1b2734490f211d14395410094f3d45095c132237053d3e10561e2a05264f132f6d57577f341f1a48295a3f1c0d323f48537a602718051a0a5a26215800394d5c595f6c4d3b4c05471a590b431e51164b304b3630145e4f402808081e0029464a1920595a6f316b0b1a38573e00551108253a0739191f20247558254f212a2f450c470e1024160a0d0f4616236f14741e110a1e03515a7755124d3209042d7b2b6e5720185d2822335139631e664744262d2b10327b57415e34510e095a5a1b2e335b40284b191d0e1411315a45393a3b147f0f260052143a150e652d243b6d4e082e322e124922283b143d5436004f3d68006a1326372c3418107b172a05224f3a261c60755d321f1e4800533f1c203b3f48005c492e180537035a26255826304d5c7b0145453f1b054e3c59264a3851124b19421030395769402c23271736296b433f205d5a46384d0b3731573e04553701720c2a303f1f24245351254f0c230945084727192416270429464510461d521e3c0338035571585c1a4d1f0022284a33475e06187021043355394a174047692f0b2b14657b5e167a19580e095e5a3227335b6d214b19190e3d18675868303a3b475b262f2652393d1b0e36050d324b4e2527142e16490b211d14105d10004b3d41095c130b3e2c341c10521e2a050f461c264f575354321f334126533b1c09323f482d556f2e1c2e180a5a2608510030490b7400454512450a4e38590f431e513f422f421467425e4f40010107173229424a192070536038490b1e38573e295c1101213a03394e37092d5351214f252a2f45254e011920160e0d0f466819601d561e150a1e037853785c1e4d36090428673a615e02185928223378304a17444740262d2b393b745e455e30510e0973531427375b44284b1934071b18355a41393a3b6a52002f225210343d0e1b0c3b324f4e0c2e322e3b402d21193f3f54360066346709581322372c343119741e2e05264f3a26625e7554361f1a48005316152f323b48045c492e310c380a5e262158263064557b0841453b4c2c4e155029431a51164b19423939105e4b40280821171f20644a1d77705a463864023838533e005537010c3325391d1f202453510c46032a2b450c4727190d1f380d0b464110461d7b17330a1a03515a5e5c3344100900284e33475e2f117f28263351394a17694e662629001632525e685716510a5e735a32271a5262284f191d0e3d18185367393e3b435b262f0f5b3634390e32050d3262471c2e363e14490b21341d395432004f3d4109751a043728341810521e030c004f3e264b5753541b163c4804533f1c09321641325c4d794c0d1e0a732f075822304d5c5d086c4c1d4c284e3c590f433758304b1d421030105e66490e0825173629424a30297f5a42384d0b1e387e3726553301253a0339301606245751254f252a064c2a47231924160e0d264f6710421d521e150a370a515a5a5c1a4d36092d216833435e061859280b3a77394e3c4647402604223632565e415e305127006c5a3627335b442862103b0e3918315a41391332655b222f265210341407140509324b4e0c2e1b2734490f211d1439541f09693d45095c132237053d3e10561e2a05264f132f6d575754321f1a48295a191c0d193948045c60273e051a0a5a2621580f396b5c590845453b4c05473c590b431e51164b304b3630145e4f402808081e1029464a1920595a6f317b0b1a38573e00551e08033a0739191f20247a58034f212a2f450c470e1002160a0d0f4641106f14741e110a1e03515a77553c4d320904284e336e5720185d2822335139631e664744262d2b10327b57675e34510e095a5a1b2e155b40284b191d0e1411175a45393a3b435b0f26265214343d0e3205243b6d4e082e322e124922283b143d5436004f3d68006a1326607c3418107b170c05224f3a264b577a5d141f1e4800533f1c203b1948005c492e180537037c26250f0f304d5c740163453f4c2c4e3c59264a3851124b19421030395769402c08211736296b433f205d5a46384d0b3731713e04553701253a2a303f1f24245351254f0c23094508472719241627040f464510461d521e3c032803555a5e5c1a4d1f0032284a33475e06187021043355394a174047692f0b2b1432525e415e195828095e5a3227335b6d216d19190e3d18315a68301c3b475b262f2652393d1b0e36050d324b4e2527142e16490b211d14105d10004b6a68090b3b0b3e0a341c10521e2a050f461c264f575354321f334126533b1c09323f482d55492e1c051e0a5a2608513630490b6608554312450a4e38590f431e513f423f421430105e4f40010107173229424a4e0870534638490b1e38573e295c1101213a0339191f092d7551214f252a2f45254e011920160e0d0f466819601d561e150a1e037853785c1e4d36090428673a615e02185928223378306c17444740262d2b393b745e455e30510e0973531427370c6d284b1934073d18355a41393a3b6a52002f225210343d0e1b0c2b324f4e0c2e322e3b402d2119431054360066344109581322372c343119521e2e05264f6d03625e7554361f1a48005316152f323b48045c492e310c380a5e262158263064557b0841453b4c2c4e155029431a51164b19423939365e4b40280821171f20644a1d20595a463864023838533e005537010c3303391d1f202453510c46032a2b450c4727190d1f280d0b464110461d7b17330a1a03515a5e5c3344360900284e33115a2f115928263351394a17694e4026292b1032525e685716510a225c5a32271a5262284f191d0e3d18185367393e3b435b262f0f5b3634390e32050d3262472a2e362e12490b21341d1f5432004f3d4109751a043728341810521e030c004f3e0d4d5753541b161a4804533f1c09321641225c4d2e18051e0a732f0758221b4b5c5d086c4c3b4c284e3c5958763858164b1d42103046596649280825173629156d3029595a42384d0b1e387e3726553301253a0339301606245751254f252a064c2a47234e0d160e0d264f67104236541e150a370a775a5a5c1a4d36092d216833435e061859280b3a77394e174047402604221032565e415e305127007c5a3627335b442862103b0e3918315a41391332655b222f265210341407320509324b4e0c2e1b2712490f211d1439541f094f3d455e75132237053d1810561e2a05264f132f6d575754321f1a48295a191c0d323f48045c60273e051a0a5a2621580f396b5c590845453b4c05471a590b431e51164b304b3630145e4f407f20081e1029464a1920595a6f314d0b1a38573e00551e08033a0739191f20247a58034f210129450c470e1002160a0d0f4641106f14521e110a1e03515a77553c4d320904284e336e5720185d2822335139631e664744262d2b10327b57415e34510e095a5a1b2e335b40284b191d0e1411175a45393a3b435b0f26005214343d0e3205243b6d4e08791b2e124922283b143d7f30004f3d68005c1326372c3418107b170c05221813264b577a5d141f1e4800536834203b2f48005c492e080337037c26255826304d5c740163453f4c2c4e3c59264a3851124b19421030395769402c08211736296b4319205d5a46384d0b3731573e04553701733f2a30191f24245351254f0c230945084727192416270429464510461d521e3c033803555a5e5c1a4d1f0022284a33475e06187021223355394a174047692f2d2b1419545e415e19580e095e5a3227335b6d214b19190e3d18315a68303a3b475b262f2652393d3d0e362e0b324b4e2527322e16490b211d14105d36004b3d41095c13043e2c341c10521e13500f463a264f575354321f334100533b1c09323f482d55492e1c051e0a5a2608512630495c5d08454512452c4e38590f431e513f4219421430105e4f40|15|17";

            Check.That(result).IsEqualTo(expected);
        }

        [Test]
        public void SuccessWhenFileIsAlreadyUnpacked()
        {
            using (var writer = new StreamWriter(_fileMapFullPath))
                writer.Write("aaaa");

            var mapLoader = new MapUnpacker();
            mapLoader.GetUnpackedMapData("10297", "0802221713");

            var result = File.ReadAllText(_fileMapFullPath);
            Check.That(result).IsEqualTo("aaaa");
        }

        [TearDown]
        public void CleanFile()
        {
            File.Delete(_fileMapFullPath);
        }
    }
}