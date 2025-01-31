﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13water
{
    class DealCards
    {
        /// <summary>
        /// 牌面从大到小排序
        /// </summary>
        public static void SortCard(List<int> cards)
        {
            //牌面从大到小排序
            cards.Sort((b, a) =>
            {
                int result = (a % 100) - (b % 100);
                if (result == 0)
                {
                    result = (a / 100) - (b / 100);
                }
                return result;
            });
        }

        /// <summary>
        /// 牌面从小到大排序
        /// </summary>
        public static void SortCardMinToMax(List<int> cards)
        {
            //面大小排序
            cards.Sort((a, b) =>
            {
                int result = (a % 100) - (b % 100);
                if (result == 0)
                {
                    result = (b / 100) - (a / 100);
                }
                return result;
            });
        }


        /// <summary>
        /// 计算一副牌里面的所有可能牌型
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
        public static List<TypeCard> GetMaxCardType(List<int> cardList)
        {
            List<TypeCard> typeCardList = new List<TypeCard>();

            //从大到小排序
            SortCard(cardList);

            //复制一份从小到大的牌
            List<int> cardList2 = cardList.GetRange(0, cardList.Count);
            SortCardMinToMax(cardList2);

            //鬼牌数量
            int smallKingNum = 616;//小王
            int bigKingNum = 717;//大王
            int KingNum = 0;
            KingNum += cardList.Contains(smallKingNum) ? 1 : 0;
            KingNum += cardList.Contains(bigKingNum) ? 1 : 0;
            int king = cardList.Contains(smallKingNum) ? smallKingNum : bigKingNum;//单王

            List<int> FiveNum = cardList.GroupBy(p => p % 100).Where(p => p.Count() >= 5).Select(p => p.Key).ToList();
            List<int> FourNum = cardList.GroupBy(p => p % 100).Where(p => p.Count() >= 4).Select(p => p.Key).ToList();
            List<int> ThreeNum = cardList.GroupBy(p => p % 100).Where(p => p.Count() >= 3).Select(p => p.Key).ToList();
            List<int> TwoNum = cardList.GroupBy(p => p % 100).Where(p => p.Count() >= 2).Select(p => p.Key).ToList();

            #region 五炸
            foreach (var Fiveitem in FiveNum)
            {
                List<int> tempList = new List<int>();
                foreach (var item in cardList)
                {
                    if (item % 100 == Fiveitem)
                    {
                        tempList.Add(item);
                    }

                    if (tempList.Count >= 5)
                    {
                        TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.FiveBomb };
                        typeCardList.Add(typeCard);
                        break;
                    }
                }

            }

            if (KingNum >= 1)
            {
                foreach (var FourItem in FourNum)
                {
                    List<int> tempList = new List<int>();
                    foreach (var item in cardList)
                    {
                        if (item % 100 == FourItem)
                        {
                            tempList.Add(item);
                        }

                        if (tempList.Count >= 4)
                        {
                            tempList.Add(king);
                            TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.FiveBomb };
                            typeCardList.Add(typeCard);
                            break;
                        }
                    }

                }
            }

            if (KingNum == 2)
            {
                foreach (var ThreeItem in ThreeNum)
                {
                    List<int> tempList = new List<int>();
                    foreach (var item in cardList)
                    {
                        if (item % 100 == ThreeItem)
                        {
                            tempList.Add(item);
                        }

                        if (tempList.Count >= 3)
                        {
                            tempList.Add(smallKingNum);
                            tempList.Add(bigKingNum);

                            TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.FiveBomb };
                            typeCardList.Add(typeCard);
                            break;
                        }
                    }

                }
            }
            #endregion

            #region 同花顺
            foreach (var item in cardList2)
            {
                if (item % 100 >= 11)
                {
                    break;
                }

                List<int> tempList = new List<int>();
                tempList.Add(item);

                foreach (var item2 in cardList2)
                {
                    if (item2 - 1 == tempList.Last())
                    {
                        tempList.Add(item2);
                    }

                    if (tempList.Count >= 5)
                    {
                        TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.TongHuaShun };
                        typeCardList.Add(typeCard);
                        break;
                    }
                }
            }

            if (KingNum >= 1)
            {
                foreach (var item in cardList2)
                {
                    if (item % 100 >= 12)
                    {
                        break;
                    }

                    List<int> tempList = new List<int>();
                    tempList.Add(item);

                    foreach (var item2 in cardList2)
                    {
                        if (item2 - 1 == tempList.Last())
                        {
                            tempList.Add(item2);
                        }

                        if (tempList.Count >= 4)
                        {
                            tempList.Add(king);
                            TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.TongHuaShun };
                            typeCardList.Add(typeCard);
                            break;
                        }
                    }
                }
            }

            if (KingNum == 2)
            {
                foreach (var item in cardList2)
                {
                    if (item % 100 >= 13)
                    {
                        break;
                    }

                    List<int> tempList = new List<int>();
                    tempList.Add(item);

                    foreach (var item2 in cardList2)
                    {
                        if (item2 - 1 == tempList.Last())
                        {
                            tempList.Add(item2);
                        }

                        if (tempList.Count >= 3)
                        {
                            tempList.Add(smallKingNum);
                            tempList.Add(bigKingNum);

                            TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.TongHuaShun };
                            typeCardList.Add(typeCard);
                            break;
                        }
                    }
                }
            }
            #endregion

            #region 炸弹
            foreach (var FourItem in FourNum)
            {
                List<int> tempList = new List<int>();
                foreach (var item in cardList)
                {
                    if (item % 100 == FourItem)
                    {
                        tempList.Add(item);
                    }

                    if (tempList.Count >= 4)
                    {
                        TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Bomb };
                        typeCardList.Add(typeCard);
                        break;
                    }
                }

            }

            if (KingNum >= 1)
            {
                foreach (var ThreeItem in ThreeNum)
                {
                    List<int> tempList = new List<int>();
                    foreach (var item in cardList)
                    {
                        if (item % 100 == ThreeItem)
                        {
                            tempList.Add(item);
                        }

                        if (tempList.Count >= 3)
                        {

                            tempList.Add(king);
                            TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Bomb };
                            typeCardList.Add(typeCard);
                            break;
                        }
                    }

                }
            }

            if (KingNum == 2)
            {
                foreach (var TwoeeItem in TwoNum)
                {
                    List<int> tempList = new List<int>();
                    foreach (var item in cardList)
                    {
                        if (item % 100 == TwoeeItem)
                        {
                            tempList.Add(item);
                        }

                        if (tempList.Count >= 2)
                        {
                            tempList.Add(smallKingNum);
                            tempList.Add(bigKingNum);

                            TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Bomb };
                            typeCardList.Add(typeCard);
                            break;
                        }
                    }

                }
            }
            #endregion

            #region 葫芦
            foreach (var ThreeItem in ThreeNum)
            {
                List<int> tempList = new List<int>();
                foreach (var item in cardList)
                {
                    if (item % 100 == ThreeItem)
                    {
                        tempList.Add(item);
                    }

                    if (tempList.Count >= 3)
                    {
                        //找两对
                        foreach (var TwoItem in TwoNum)
                        {
                            if (ThreeItem != TwoItem)
                            {
                                foreach (var AllItem in cardList)
                                {
                                    if (AllItem % 100 != ThreeItem && AllItem % 100 == TwoItem)
                                    {
                                        tempList.Add(AllItem);
                                    }

                                    if (tempList.Count >= 5)
                                    {
                                        TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Gourd };
                                        typeCardList.Add(typeCard);
                                        tempList = typeCard.cardList.GetRange(0, 3);
                                        break;
                                    }
                                }


                            }

                        }
                        break;
                    }
                }
            }

            if (KingNum >= 1)
            {
                foreach (var ThreeItem in TwoNum)
                {
                    List<int> tempList = new List<int>();
                    foreach (var item in cardList)
                    {
                        if (item % 100 == ThreeItem)
                        {
                            tempList.Add(item);
                        }

                        if (tempList.Count >= 2)
                        {
                            //找两对
                            foreach (var TwoItem in TwoNum)
                            {
                                if (ThreeItem != TwoItem)
                                {
                                    foreach (var AllItem in cardList)
                                    {
                                        if (AllItem % 100 != ThreeItem && AllItem % 100 == TwoItem)
                                        {
                                            tempList.Add(AllItem);
                                        }

                                        if (tempList.Count >= 4)
                                        {
                                            tempList.Add(king);
                                            TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Gourd };
                                            typeCardList.Add(typeCard);
                                            tempList = typeCard.cardList.GetRange(0, 2);
                                            break;
                                        }
                                    }


                                }

                            }
                            break;
                        }
                    }
                }
            }

            if (KingNum == 2)
            {
                //不用算
            }

            #endregion

            #region 同花
            List<int> FiveColor = cardList.GroupBy(p => p / 100).Where(p => p.Count() >= 5).Select(p => p.Key).ToList();
            List<int> FourColor = cardList.GroupBy(p => p / 100).Where(p => p.Count() >= 4).Select(p => p.Key).ToList();
            List<int> ThreeColor = cardList.GroupBy(p => p / 100).Where(p => p.Count() >= 3).Select(p => p.Key).ToList();

            foreach (var Fiveitem in FiveColor)
            {
                List<int> tempList = new List<int>();
                foreach (var item in cardList)
                {
                    if (item / 100 == Fiveitem)
                    {
                        tempList.Add(item);
                    }
                }

                while (true)
                {
                    if (tempList.Count >= 5)
                    {
                        TypeCard typeCard = new TypeCard() { cardList = tempList.GetRange(0, 5), cardType = DeckTypeEnum.TongHua };
                        typeCardList.Add(typeCard);
                        tempList.RemoveAt(0);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (KingNum >= 1)
            {
                foreach (var Fouritem in FourColor)
                {
                    List<int> tempList = new List<int>();
                    foreach (var item in cardList)
                    {
                        if (item / 100 == Fouritem)
                        {
                            tempList.Add(item);
                        }
                    }

                    while (true)
                    {
                        if (tempList.Count >= 4)
                        {
                            TypeCard typeCard = new TypeCard() { cardList = tempList.GetRange(0, 4), cardType = DeckTypeEnum.TongHua };
                            typeCard.cardList.Add(king);
                            typeCardList.Add(typeCard);
                            tempList.RemoveAt(0);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (KingNum == 2)
            {
                foreach (var Threeitem in ThreeColor)
                {
                    List<int> tempList = new List<int>();
                    foreach (var item in cardList)
                    {
                        if (item / 100 == Threeitem)
                        {
                            tempList.Add(item);
                        }
                    }

                    while (true)
                    {
                        if (tempList.Count >= 3)
                        {
                            TypeCard typeCard = new TypeCard() { cardList = tempList.GetRange(0, 3), cardType = DeckTypeEnum.TongHua };
                            typeCard.cardList.Add(smallKingNum);
                            typeCard.cardList.Add(bigKingNum);
                            typeCardList.Add(typeCard);
                            tempList.RemoveAt(0);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            #endregion

            #region 顺子

            foreach (var MaxItem in cardList)
            {

                if (MaxItem % 100 <= 5)
                {
                    break;//从大到小，后面的也不需要循环了
                }

                List<int> tempList = new List<int>();
                tempList.Add(MaxItem);

                while (tempList.Count < 5)
                {

                    bool flag = false;

                    foreach (var item in cardList)
                    {
                        if (item % 100 + 1 == tempList.Last() % 100)
                        {
                            tempList.Add(item);
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }

                if (tempList.Count >= 5)
                {
                    TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.ShunZi };
                    typeCardList.Add(typeCard);
                }
            }

            if (KingNum >= 1)
            {
                foreach (var MaxItem in cardList)
                {

                    if (MaxItem % 100 <= 4)
                    {
                        break;//从大到小，后面的也不需要循环了
                    }

                    List<int> tempList = new List<int>();
                    tempList.Add(MaxItem);

                    while (tempList.Count < 4)
                    {

                        bool flag = false;

                        foreach (var item in cardList)
                        {
                            if (item % 100 + 1 == tempList.Last() % 100)
                            {
                                tempList.Add(item);
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            break;
                        }
                    }

                    tempList.Add(king);
                    if (tempList.Count >= 5)
                    {
                        TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.ShunZi };
                        typeCardList.Add(typeCard);
                    }


                }
            }

            if (KingNum == 2)
            {
                foreach (var MaxItem in cardList)
                {

                    if (MaxItem % 100 <= 3)
                    {
                        break;//从大到小，后面的也不需要循环了
                    }

                    List<int> tempList = new List<int>();
                    tempList.Add(MaxItem);

                    while (tempList.Count < 3)
                    {

                        bool flag = false;

                        foreach (var item in cardList)
                        {
                            if (item % 100 + 1 == tempList.Last() % 100)
                            {
                                tempList.Add(item);
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            break;
                        }
                    }

                    tempList.Add(smallKingNum);
                    tempList.Add(bigKingNum);
                    if (tempList.Count >= 5)
                    {
                        TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.ShunZi };
                        typeCardList.Add(typeCard);
                    }


                }
            }

            #endregion

            #region 三张
            foreach (var Threeitem in ThreeNum)
            {
                List<int> tempList = new List<int>();
                foreach (var item in cardList)
                {
                    if (item % 100 == Threeitem)
                    {
                        tempList.Add(item);
                    }

                    if (tempList.Count >= 3)
                    {
                        TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Three };
                        typeCardList.Add(typeCard);
                        break;
                    }
                }
            }

            if (KingNum >= 1)
            {
                foreach (var Twoitem in TwoNum)
                {
                    List<int> tempList = new List<int>();
                    foreach (var item in cardList)
                    {
                        if (item % 100 == Twoitem)
                        {
                            tempList.Add(item);
                        }

                        if (tempList.Count >= 2)
                        {
                            tempList.Add(king);
                            TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Three };
                            typeCardList.Add(typeCard);
                            break;
                        }
                    }
                }
            }

            if (KingNum == 2)
            {
                foreach (var item in cardList)
                {
                    List<int> tempList = new List<int>();
                    if (item != smallKingNum || item != bigKingNum)
                    {
                        tempList.Add(smallKingNum);
                        tempList.Add(bigKingNum);
                        TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Three };
                        typeCardList.Add(typeCard);
                    }
                }
            }

            #endregion

            #region 两对

            for (int i = 0; i < TwoNum.Count; i++)
            {
                List<int> tempList = new List<int>();

                foreach (var item in cardList)
                {
                    if (item % 100 == TwoNum[i])
                    {
                        tempList.Add(item);
                    }
                }

                while (tempList.Count >= 2)
                {

                    for (int j = i + 1; j < TwoNum.Count; j++)
                    {
                        List<int> tempList2 = new List<int>();
                        foreach (var item in cardList)
                        {
                            if (item % 100 == TwoNum[j])
                            {
                                tempList2.Add(item);
                            }
                        }

                        while ((tempList2.Count >= 2))
                        {
                            TypeCard typeCard = new TypeCard() { cardList = tempList.GetRange(0, 2), cardType = DeckTypeEnum.TwoDouble };
                            typeCard.cardList.AddRange(tempList2.GetRange(0, 2));
                            typeCardList.Add(typeCard);
                            tempList2.RemoveAt(0);
                        }

                    }

                    tempList.RemoveAt(0);

                }

            }

            if (KingNum >= 1)
            {
                //不需要
            }

            if (KingNum == 2)
            {
                //不需要
            }

            #endregion

            #region 对子

            foreach (var Twoitem in TwoNum)
            {
                List<int> tempList = new List<int>();

                foreach (var item in cardList)
                {
                    if (item % 100 == Twoitem)
                    {
                        tempList.Add(item);
                    }
                }

                while (tempList.Count >= 2)
                {
                    TypeCard typeCard = new TypeCard() { cardList = tempList.GetRange(0, 2), cardType = DeckTypeEnum.Double };
                    typeCardList.Add(typeCard);
                    tempList.RemoveAt(0);
                }
            }


            if (KingNum >= 1)
            {
                foreach (var item in cardList)
                {
                    List<int> tempList = new List<int>();
                    if (item != smallKingNum || item != bigKingNum)
                    {
                        tempList.Add(king);
                        TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Double };
                        typeCardList.Add(typeCard);
                    }
                }
            }

            if (KingNum == 2)
            {
                //不用算
            }

            #endregion


            //乌龙-只拿三张牌
            if (true)
            {
                if (cardList.Count < 3)
                {
                    Console.WriteLine("*****************************************************************最后剩牌不足三张");
                }
                else
                {
                    List<int> tempList = new List<int>();
                    tempList = cardList.GetRange(0, 3);
                    TypeCard typeCard = new TypeCard() { cardList = tempList, cardType = DeckTypeEnum.Single };
                    typeCardList.Add(typeCard);
                }


            }

            return typeCardList;
        }


        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="list"></param>
        /// <param name="element"></param>
        public static void DeleteListElement(List<int> list, List<int> element)
        {
            foreach (var item in element)
            {
                list.Remove(item);
            }
        }


        /// <summary>
        /// 得到所有自动牌型
        /// </summary>
        /// <param name="cmlist"></param>
        /// <param name="CardList"></param>
        /// <returns></returns>
        public static List<CardModel> GetAllResult(List<CardModel> cmlist, List<int> CardList)
        {
            CardModel cm = new CardModel();
            List<TypeCard> typeCardList = new List<TypeCard>();

            //新建一个副本
            List<int> newCardlist = CardList.Select(p => p).ToList();

            //第一个
            if (cmlist.Count == 0)
            {
                while (true)
                {

                    typeCardList = GetMaxCardType(newCardlist);

                    //首道只能有三张牌
                    if (cm.typeCardList.Count == 2 && typeCardList[0].cardList.Count > 3)
                    {
                        typeCardList = GetMaxCardType(typeCardList[0].cardList.GetRange(0, 3));
                    }

                    cm.typeCardList.Add(typeCardList[0]);
                    DeleteListElement(newCardlist, typeCardList[0].cardList);

                    //补全少的牌
                    if (cm.typeCardList.Count >= 3)
                    {
                        for (int i = 0; i < cm.typeCardList.Count; i++)
                        {
                            if (i == 2)
                            {
                                while (cm.typeCardList[i].cardList.Count < 3)
                                {
                                    cm.typeCardList[i].cardList.Add(newCardlist[0]);
                                    newCardlist.RemoveAt(0);
                                }
                            }
                            else
                            {
                                while (cm.typeCardList[i].cardList.Count < 5)
                                {
                                    cm.typeCardList[i].cardList.Add(newCardlist[0]);
                                    newCardlist.RemoveAt(0);
                                }
                            }

                        }

                        break;
                    }
                }

                cmlist.Add(cm);

                GetAllResult(cmlist, CardList);
            }


            //其他自动
            if (cmlist.Count < 4)
            {
                int SingleCount = 0;//乌龙次数
                while (true)
                {
                    typeCardList = GetMaxCardType(newCardlist);
                    int index = cmlist.Count;//第几组自动
                    int typeCardListIndex = 0;

                    if (cm.typeCardList.Count == 3)
                    {

                    }
                    else if (cm.typeCardList.Count == 0)
                    {
                        if (typeCardList.Count < index)
                        {
                            return cmlist;
                        }

                        cm.typeCardList.Add(typeCardList[index]);
                        DeleteListElement(newCardlist, typeCardList[index].cardList);
                    }
                    else
                    {
                        //前道的牌不能大于后道
                        while (true)
                        {
                            if (typeCardList[typeCardListIndex].cardType > cm.typeCardList.Last().cardType)
                            {
                                typeCardListIndex++;
                                continue;
                            }
                            if (typeCardList[typeCardListIndex].cardType == cm.typeCardList.Last().cardType)
                            {
                                if (typeCardList[typeCardListIndex].cardList.Max() >= cm.typeCardList.Last().cardList.Max())
                                {
                                    return cmlist;
                                }
                            }

                            break;
                        }

                        //首道只能有三张牌
                        if (cm.typeCardList.Count == 2 && typeCardList[typeCardListIndex].cardList.Count > 3)
                        {
                            typeCardList = GetMaxCardType(typeCardList[typeCardListIndex].cardList.GetRange(0, 3));
                            cm.typeCardList.Add(typeCardList[0]);
                            DeleteListElement(newCardlist, typeCardList[0].cardList);
                        }
                        else
                        {
                            cm.typeCardList.Add(typeCardList[typeCardListIndex]);
                            DeleteListElement(newCardlist, typeCardList[typeCardListIndex].cardList);
                        }

                    }

                    //补全不够牌的
                    if (cm.typeCardList.Count >= 3)
                    {
                        for (int i = 0; i < cm.typeCardList.Count; i++)
                        {
                            if (i == 2)
                            {
                                while (cm.typeCardList[i].cardList.Count < 3)
                                {
                                    cm.typeCardList[i].cardList.Add(newCardlist[0]);
                                    newCardlist.RemoveAt(0);
                                }
                            }
                            else
                            {
                                while (cm.typeCardList[i].cardList.Count < 5)
                                {
                                    cm.typeCardList[i].cardList.Add(newCardlist[0]);
                                    newCardlist.RemoveAt(0);
                                }
                            }

                            if (cm.typeCardList[i].cardType == DeckTypeEnum.Single)
                            {
                                SingleCount++;
                            }

                        }

                        break;
                    }
                }

                cmlist.Add(cm);

                if (SingleCount >= 2)
                {
                    return cmlist;
                }

                GetAllResult(cmlist, CardList);

            }

            return cmlist;
        }


        /// <summary>
        /// 牌型对应如下：
        /// 1->$
        /// 2->&
        /// 3->*
        /// 4->#
        /// </summary>
        public static void Deal()
        {

            List<CardModel> cmlist = new List<CardModel>();
            //List<int> CardList = new List<int>() { 102, 203, 204, 205, 206, 207, 208, 309, 410, 111, 112, 113, 114 };//自定义13张手牌
            List<int> CardList = new List<int>();

            convert1();//将card转换成cardInt
            for (int i=0;i<13;i++)
            {
                CardList.Add(User.cardInt[i]);
            }
            cmlist = GetAllResult(cmlist, CardList);

            Console.WriteLine("玩家手牌信息为：");
            SortCardMinToMax(CardList);
            foreach (var item in CardList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("自动计算的牌型信息：");
            Console.WriteLine("");

            foreach (var item in cmlist)
            {
                int flag = 1;
                if ((item.typeCardList[0].cardType.ToString() == "TwoDouble") && (item.typeCardList[1].cardType.ToString() == "TwoDouble") && ((item.typeCardList[1].cardList[0] % 100) - (item.typeCardList[1].cardList[2] % 100) == 1) && ((item.typeCardList[0].cardList[0] % 100) - (item.typeCardList[0].cardList[2] % 100) > 1))
                {
                    foreach (var item2 in item.typeCardList)
                    {

                        for (int i = 0; i < item2.cardList.Count; i++)
                        {
                            if (flag == 1)
                            {
                                User.second[i] = item2.cardList[i];
                            }
                            else if (flag == 2)
                            {
                                User.third[i] = item2.cardList[i];
                            }
                            else if (flag == 3)
                            {
                                User.first[i] = item2.cardList[i];
                            }
                        }
                        flag++;
                    }
                }
                else
                {
                    foreach (var item2 in item.typeCardList)
                    {

                        for (int i = 0; i < item2.cardList.Count; i++)
                        {
                            if (flag == 1)
                            {
                                User.third[i] = item2.cardList[i];
                            }
                            else if (flag == 2)
                            {
                                User.second[i] = item2.cardList[i];
                            }
                            else if (flag == 3)
                            {
                                User.first[i] = item2.cardList[i];
                            }
                        }
                        flag++;
                    }
                }
                break;//中断程序，只取生成的第一种牌型
            }


            reverse1();

        }

        /// <summary>
        /// 将card转换成cardInt
        /// </summary>
        public static void convert1()
        {
            int cnt = 0;
            for (int i = 0; i < User.card.Length; i += 3)
            {
                if(User.card[i]==' ')//牌面为10
                {
                    i++;
                }
                if (User.card[i] == '$')
                {
                    User.cardInt[cnt] = 100 + convert2(User.card[i + 1]);
                }
                else if (User.card[i] == '&')
                {
                    User.cardInt[cnt] = 200 + convert2(User.card[i + 1]);
                }
                else if (User.card[i] == '*')
                {
                    User.cardInt[cnt] = 300 + convert2(User.card[i + 1]);
                }
                else if (User.card[i] == '#')
                {
                    User.cardInt[cnt] = 400 + convert2(User.card[i + 1]);
                }
                cnt++;
            }

        }
        /// <summary>
        /// 转换牌面数字
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        public static int convert2(char tmp)
        {
            if(tmp== 'A')
            {
                return 14;
            }
            else if(tmp=='J')
            {
                return 11;
            }
            else if(tmp=='Q')
            {
                return 12;
            }
            else if(tmp=='K')
            {
                return 13;
            }
            else if(tmp=='1')
            {
                return 10;
            }
            else
            {
                return tmp-48;
            }
        }

        /// <summary>
        /// 牌型对应如下：
        /// 1->$
        /// 2->&
        /// 3->*
        /// 4->#
        /// 206,409,309,113,112,111,312,402,110,104,303,311,313
        /// </summary>
        public static void reverse1()
        {
            reverse2(User.first, User.cardFirst);
            reverse2(User.second, User.cardSecond);
            reverse2(User.third, User.cardThird);
        }

        /// <summary>
        /// 将数值型牌转换成带花色的牌
        /// </summary>
        /// <param name="from">数值型牌</param>
        /// <param name="to">带花色牌</param>
        public static void reverse2(int[] from,List<string> to)
        {
            foreach (var item in from)
            {
                string huase;
                string number;
                int huaseCal = item / 100;
                int numberCal = item % 100;
                if (huaseCal == 1)
                {
                    huase = "$";
                }
                else if (huaseCal == 2)
                {
                    huase = "&";
                }
                else if (huaseCal == 3)
                {
                    huase = "*";
                }
                else
                {
                    huase = "#";
                }

                if (numberCal == 14)
                {
                    number = "A";
                }
                else if (numberCal == 11)
                {
                    number = "J";
                }
                else if (numberCal == 12)
                {
                    number = "Q";
                }
                else if (numberCal == 13)
                {
                    number = "K";
                }
                else
                {
                    number = numberCal.ToString();
                }

                to.Add(huase + number);
            }

        }
    }
}
