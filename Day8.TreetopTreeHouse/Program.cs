﻿using System.Diagnostics;

var visibleTrees = new List<Tree>();
var input = "000110211310120301121312200301013204213433321324454125534120411314221421432204213123312010120220212\r\n020012220322312203320423330100141123432232555552131513413333243201041414120414404222300212031212210\r\n012220223030033030244430211234220045555352514254335343332514243345202201013120303123003031322301122\r\n122212123203002004034001203313232515112543525251445353434224414533524014020242242322320223010131111\r\n221102333103333221411324203034235135343455415425134251221521352512445343444242410343133031022213111\r\n012230110220232130043321130142424543415542352534155145434324432553532253510101043422110311302133322\r\n121211332110331222432012225134422432341112144421535153351545122134242232152130110334114400332212301\r\n021003020222222304114022552315552411255554221162455263643351112333322235214353424140101110301013303\r\n211101331332303134320025235254523341134225246335554356533426415514344521433235223100024100322012213\r\n333121033001133202211331144545334545442426462335662255342342626524313432432255113203322322002312200\r\n010322322141333044304115552115413253563353625666244464226452656243424545525555553333333441121311231\r\n032330304041422420432124324244236264255242536445626642464646454324353143112245143242140134012131113\r\n113222323414023431235314252222246225364232452564335525523344525664226653522112244131121334130320322\r\n121002342323322351314412423235433523643565644552335525522462425253643354453342113152132444223043001\r\n303334322134140123154241513636446642663346536533667552624355222224332425555525121255313000110224301\r\n220002230431013514545542433426226364623335746773567356566543235364324426533313525143244100121033121\r\n000021230222223532342154546526322562455734556753354636566447345465225625536633243334425112234211423\r\n100240131421551532143146364665353436655665676767645757767765365733656436442643144352144332403323231\r\n231322213332442222125662224633422364634335777574764763343776757435645252662432644231412254011230044\r\n120320134105242421434423353553635756666465645446464476746533434474737333355643266531333324433212400\r\n040301032133333254244335264252755376435754666436667554445363634375377335452223443455551432333010144\r\n122213043542434415443363356663454534757746355453573654756377543673443533255466446625122132310014334\r\n404243133333412213345434336533364653576735676667576876848337555643553537554265552455111211141430132\r\n443341301142235415336322424546477554637688787745866488887577434344636437734332223546335121555322312\r\n010101032453544354452355447644336446437444776676584487868688446743777537543333245666541212524431033\r\n130342114125121245655353346445355733446776587588784546588474685553536367574445523434254125522412333\r\n201242125553223436463223777745535566487874456667845657466784588644655657455355352552555444112241410\r\n234243354255336642454256767534444878687668756444875858587854778474484437455656353656253411335452400\r\n314411514514125254223353563444477554768588585448654748855456656667558676453446723446433551542333323\r\n320425133145356325256655577477467888556845884576957768675647786647464447677575756555366251552252023\r\n402024545131232242524557435777674845786545558766585956759687647846545584454443736545244555225513404\r\n221122211244626363325464534767668748756767978988996968588875755867566656577763547532353323245443324\r\n241532435425235552535674564444576465866975867987658575886697775645646467874734565535246546512244511\r\n003324252512442566553463345787864877859757886699855979689556865965885747456343365533654353244413223\r\n212315155352232566544737454548674574998798699555866589956966599795788486474536636336336342425134412\r\n415441242523246256336374766665674457785867567956675565789686897696764587674446666642422423644424325\r\n003554554162525244354667375865755578679858897996697678587867758755877644755534673566366364215111142\r\n125233324364265264545556378688676958976975966767698999896779575577774547466453456456443363332524521\r\n133515233335323373765654467667486986756665797876767877886899897979969475847765767637544446523515551\r\n423321431443554355375376748446757899656688998798978687676986796699688855776746674753723255464344423\r\n135533214666522656775554775567665797957679899988997898976779768787598768878445373375735633533152423\r\n424233114545442654745646856857767575855668667669968786879669768579688844877458655735443652256255431\r\n122311356255465443775736754747756597959866677969777897778796669799996864878444747533472262262432453\r\n444412515423634374457557568574698568569796689667999968899788697787968667768664344766546653236143151\r\n152311513646633365333568844555559779697686687699777998989779788768756594585758837374575424224211225\r\n432411444656462746443756865787956975798986999787977978996987778795768586656655473453364365634145515\r\n512553242524235344467755668868885977997876879978998878787888776866887566586456466377353633526612112\r\n115351124324666765477575484768566785899876668997898988879879687896986577677786744336653645225533134\r\n521325356522544377445774755666867759866698988779997998778687879779588576866784766376455535443334445\r\n433451166554445354353554886675567598968878879979777887878988976979689787756548837435743345242455141\r\n251112342434644676347767747746557587886869778877788877789787767787779598548856756754774536542212331\r\n255533535452264557543768667886686886969966689777797988888776799775755889645756557644656535253352415\r\n324425154344254736457678866646677886667896679787789878898879666995998757877665757356457366362624453\r\n133124434355236446553476678549686757888986787979777777777688968798699766877778645555763233323653111\r\n222452162524456534544666745659767986569977869888798889797967869896588579678645466757742223536551125\r\n424113153224246464437444666655586769888767899997999998888899787785789988565667547344466324245444121\r\n342222535222265477673374467445978889589796696777887788896778866766575958886864746654456432465143345\r\n343222443646553344666565758455597897568767997897989877768698886656896987444854633767335332566315312\r\n031554353342263455343465844688566996587977697767668887776787776985778754456646747553435562222553224\r\n433344426223464443364358688754655656655796979887796696799797776855755885854676557736723432655514323\r\n013424132332422364434378758577758958968878668787687777668989797955778846555856344635566224523432451\r\n425553255655633236466566556555858699675969687978968799698978595977567446657483654746364253324544543\r\n432514124535636275635556647685849565689989686678799779666769657669586678877883365364425535653142315\r\n234213331454244233774547658465845955685598696976697898886596997865578648447647767565654326321345225\r\n033142335256632253667547655784646566787758855877679696866998778855965474867574633636266434253231343\r\n433312355254243222736457466486484557878576698897857857878667659897748755645557367664665624322214245\r\n414352553244643424464634565857556876595979575859559697897855757678648446474443347476454343621315123\r\n142445323134524455344767565745845466776955777775867689676669795765547875554364474423523255433452550\r\n420122443552465225677645453567777645666955697588578797786675779777688864467444476525625534353143351\r\n013443533555256553426677376778475746848576769888786588999657647784787744733675443533555552342334414\r\n041143134325455654456573473653567744748677959966765568889765584875786654736746477425243323345412331\r\n432143141143446546334633656476476747668864878778688989957788768655568457357565474424624643255141123\r\n433102225554544652566677347757675544755546776854548575485655786465456345347635444252452425412221021\r\n323443424115135364655624436464533765445864646766688454775574785855547635756475456566323553413444404\r\n040133323452356462366536677466667655766665575477656846545868855587636377637445452653223313533353431\r\n112321424255322325434562636744647576545484488884676746485886457756657434733352222326531315442212112\r\n414000041225332224365336457576353475444476854684468466666787764643346356664452563552325454125532334\r\n333211225554233356326636546733667664766764488678465547455847554453346674333644366565122142144303010\r\n201332104431213354534342624674574463634343535468776645455555777363557644444632234452452514524001241\r\n221121011452151314652546563557737463367364573534653347663557476557753774362253653622553112413343020\r\n301020124355152323443536262535766773343757377576554465333456475773466764562232455333212154220142002\r\n322244112312155113454636553224336764436375336773533577673334677767346562553664626122341142230310021\r\n023103242244551224134442622342463557736536665447475654776476664656746264566536561531213151202033312\r\n000241244142514451335326646524645362354365656733573556434643567466354436652444155224421243124420312\r\n211134103233321112311333366243566524426453645455335474755773645624422266326533321441535122300041202\r\n010100412012005141235135226623364644564632374554665337675444336522352336344211133431343203034321031\r\n120100431404011341421515543345452262445624345326474644544443332326425454424431513314250240023131303\r\n302230432233042151414231553363365325522333634334265345542443426352642445554145124343411121104121203\r\n303233311431323211311335332253563563355242335445366433543356662343656654554132224132234403131422203\r\n113031120441440344151555331254253525425556245652343434526624622453624343111341315343030233140303323\r\n113030023221043232305142142324135442534246224522233522334666345254334253143442354430224400423233033\r\n031102021123340100023323433221314345163424223524353422623255522232122453215412122243144210131021220\r\n123100111112040244104314311535251111141234335442354234236235354514311422435123332031213231120131013\r\n221222103112033302010413133424335241315253243263446652241133155434215112225523013040443233102021312\r\n000012122130221202130324443534215451343511144224113442315342555214421524454224402343214132100123030\r\n112012230223002044203111222225321532514541153222214115443212344354545231533442344002011210202230120\r\n221200232013222231032340233141433354514311213113224441111332422254143133440204220101431230200002121\r\n211212213121303211020441232042142451254444244521121152121224435112515234204202321124222332312210022\r\n202120032200122003044340422223002041534554215334252122413441432141223402244034330212233311001312221";
//var input = "123\r\n123\r\n123";
string[] forest = input.Split("\r\n");
var scores = new List<int>();


var timer = new Stopwatch();
timer.Start();
for (int i = 0; i < forest.Length; i++) {
  for (int j = 0; j < forest[i].Length; j++) {
    int treesInView = 0;
    bool left = isVisible(j, i, -1, 0, int.Parse(forest[i][j].ToString()),treesInView);
    bool right = isVisible(j, i, 1, 0, int.Parse(forest[i][j].ToString()), treesInView);
    bool top = isVisible(j, i, 0, 1, int.Parse(forest[i][j].ToString()), treesInView);
    bool bottom = isVisible(j, i, 0, -1, int.Parse(forest[i][j].ToString()),treesInView);
    if (left || right || top || bottom) {
      Tree tempTree = new();
      tempTree.x = j;
      tempTree.y = i;
      tempTree.height = int.Parse(forest[i][j].ToString());
      tempTree.visible = true;
      visibleTrees.Add(tempTree);
    }
  }
}

Console.WriteLine(visibleTrees.Count);

for (int i = 0; i < forest.Length; i++) {
  for (int j = 0; j < forest[i].Length; j++) {
    int left = scenicScore(j, i, -1, 0, int.Parse(forest[i][j].ToString()));
    int right = scenicScore(j, i, 1, 0, int.Parse(forest[i][j].ToString()));
    int top = scenicScore(j, i, 0, 1, int.Parse(forest[i][j].ToString()));
    int bottom = scenicScore(j, i, 0, -1, int.Parse(forest[i][j].ToString()));
    scores.Add(left * right * top * bottom);
  }
}
timer.Stop();
Console.WriteLine($"Time: {timer.ElapsedMilliseconds}ms");
Console.WriteLine(scores.Max());

bool isVisible(int x, int y, int xdirection, int ydirection, int height,int treesInView) {
  if (x == 0 || x == forest[0].Length - 1 || y == 0 || y == forest.Length - 1) {
    return true;
  }
  if (int.Parse(forest[y + ydirection][x + xdirection].ToString()) >= height) {
    return false;
  }
  return isVisible(x + xdirection, y + ydirection, xdirection, ydirection, height, treesInView);
}

int scenicScore(int x, int y, int xdirection, int ydirection, int height) { 
  if (x == 0 || x == forest[0].Length - 1 || y == 0 || y == forest.Length - 1) {
    return 0;
  }
  if (int.Parse(forest[y + ydirection][x + xdirection].ToString()) >= height) {
    return 1;
  }
  return 1 + scenicScore(x + xdirection, y + ydirection, xdirection, ydirection, height);
}

public class Tree {
  public int x;
  public int y;
  public int height;
  public bool visible = false;
  public int score = 0;

}
