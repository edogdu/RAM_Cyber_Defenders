#include <iostream>
#include <cstdlib>
#include <ctime>
#include <vector>
#include <stack>
#include <iomanip>

using namespace std;

void callTheCardInfos();
vector<int> shuffleTheCards();
int startGame();

vector<int> gameInProgress(vector<int>);

void showCardsInfos(int&, vector<int>&);
void creatGameTable(vector<int>, vector<int>, vector<int>, vector<int>, vector<int>);
void incrementTurn(int&);
int  makingChoice();
void wasteCard();
bool enableAImode(int num); 

void blueCard(vector<int>&, vector<bool>&, vector<int>&, int&, vector<bool>&);

void greenCard(vector<int>&, vector<int>&, vector<bool>&, vector<int>&, int&);
void greenCard_detectBlueCards(vector<int>&, vector<bool>&, vector<int>&, int&, vector<int>&);
void greenCard_makingDecisions(vector<int>&, vector<int>&, vector<int>&, vector<bool>&, int&);

void redCard(vector<int>&, vector<int>&, vector<int>&, vector<bool>&, vector<bool>&, int&);
void redCard_detectBlueCards(vector<int>&, vector<int>&, vector<int>&, int&);
void redCard_detectDeletableBlue(vector<int>&, vector<int>&, int&, vector<int>&);
void redCard_finallyAttackGreen(vector<int>&, vector<bool>&, int&);
void redCard_finallyAttackBlue(vector<int>&, vector<bool>&, int&);

vector<int>getGameResult(vector<int>&, vector<int>&, vector<int>&);

void showResult(vector<int>);

struct
{
	int cardCode = 0;
	string cardsName = "cname";
	string cardType = "ctype";
	int typeNo = 0;
	string cardAttribute = "cattr";
	int attributeCode = 0;

} card[50];

int main()
{
	callTheCardInfos(); // getting card informations

	int status = startGame();

	if (status == 0)
	{
		cout << "See you later!!";
		return 0;
	}
	else // determine pvp or pvai
	{
		int decision;
		bool mode;

		cout << "Type '1' for player vs player" << endl << "Type '2' for player vs computer" 
			<< endl << "Type other number to quit the game" << endl;
		cout << "Your choice is: "
		cin >> decision;

		if (decision == 1 || decision == 2) 
		{
			mode = enableAImode(decision);
		}
		else
		{
			cout << "See you later!!";
			return 0;
		}
	}

	vector<int> deck = shuffleTheCards(); // generate random numbers 0 to 49

	vector<int> blueCardsResult = gameInProgress(deck, playWithAI);

	showResult(blueCardsResult);

	return 0;
}

vector<int> shuffleTheCards()
{
	time_t seed = time(0);

	srand(seed);

	vector<int> happy;
	vector<int> deck;

	for (int i = 0; i < 50; i++)
	{
		happy.push_back(i);
	}

	while (happy.size() != 0)
	{
		int num = rand() % happy.size();

		deck.push_back(happy[num]);
		happy.erase(happy.begin() + num);
	}

	return deck;
}

void callTheCardInfos()
{
	card[0].cardCode = 0, card[0].cardsName = "Game_Console", card[0].cardType = "Asset", card[0].typeNo = 1, card[0].cardAttribute = "Shield", card[0].attributeCode = 1;
	card[1].cardCode = 1, card[1].cardsName = "Game_Console", card[1].cardType = "Asset", card[1].typeNo = 1, card[1].cardAttribute = "Shield", card[1].attributeCode = 1;
	card[2].cardCode = 2, card[2].cardsName = "Game_Console", card[2].cardType = "Asset", card[2].typeNo = 1, card[2].cardAttribute = "Shield", card[2].attributeCode = 1;
	card[3].cardCode = 3, card[3].cardsName = "Game_Console", card[3].cardType = "Asset", card[3].typeNo = 1, card[3].cardAttribute = "Shield", card[3].attributeCode = 1;
	card[4].cardCode = 4, card[4].cardsName = "Computer", card[4].cardType = "Asset", card[4].typeNo = 1, card[4].cardAttribute = "Lock", card[4].attributeCode = 2;
	card[5].cardCode = 5, card[5].cardsName = "Computer", card[5].cardType = "Asset", card[5].typeNo = 1, card[5].cardAttribute = "Lock", card[5].attributeCode = 2;
	card[6].cardCode = 6, card[6].cardsName = "Computer", card[6].cardType = "Asset", card[6].typeNo = 1, card[6].cardAttribute = "Lock", card[6].attributeCode = 2;
	card[7].cardCode = 7, card[7].cardsName = "Computer", card[7].cardType = "Asset", card[7].typeNo = 1, card[7].cardAttribute = "Lock", card[7].attributeCode = 2;
	card[8].cardCode = 8, card[8].cardsName = "Cell_Phone", card[8].cardType = "Asset", card[8].typeNo = 1, card[8].cardAttribute = "Wireless", card[8].attributeCode = 3;
	card[9].cardCode = 9, card[9].cardsName = "Cell_Phone", card[9].cardType = "Asset", card[9].typeNo = 1, card[9].cardAttribute = "Wireless", card[9].attributeCode = 3;
	card[10].cardCode = 10, card[10].cardsName = "Cell_Phone", card[10].cardType = "Asset", card[10].typeNo = 1, card[10].cardAttribute = "Wireless", card[10].attributeCode = 3;
	card[11].cardCode = 11, card[11].cardsName = "Cell_Phone", card[11].cardType = "Asset", card[11].typeNo = 1, card[11].cardAttribute = "Wireless", card[11].attributeCode = 3;
	card[12].cardCode = 12, card[12].cardsName = "Private_Information", card[12].cardType = "Asset", card[12].typeNo = 1, card[12].cardAttribute = "House", card[12].attributeCode = 4;
	card[13].cardCode = 13, card[13].cardsName = "Private_Information", card[13].cardType = "Asset", card[13].typeNo = 1, card[13].cardAttribute = "House", card[13].attributeCode = 4;
	card[14].cardCode = 14, card[14].cardsName = "Private_Information", card[14].cardType = "Asset", card[14].typeNo = 1, card[14].cardAttribute = "House", card[14].attributeCode = 4;
	card[15].cardCode = 15, card[15].cardsName = "Private_Information", card[15].cardType = "Asset", card[15].typeNo = 1, card[15].cardAttribute = "House", card[15].attributeCode = 4;

	card[16].cardCode = 16, card[16].cardsName = "Anti_Malware", card[16].cardType = "Defense", card[16].typeNo = 2, card[16].cardAttribute = "Shield", card[16].attributeCode = 1;
	card[17].cardCode = 17, card[17].cardsName = "Anti_Malware", card[17].cardType = "Defense", card[17].typeNo = 2, card[17].cardAttribute = "Shield", card[17].attributeCode = 1;
	card[18].cardCode = 18, card[18].cardsName = "Anti_Malware", card[18].cardType = "Defense", card[18].typeNo = 2, card[18].cardAttribute = "Shield", card[18].attributeCode = 1;
	card[19].cardCode = 19, card[19].cardsName = "Anti_Malware", card[19].cardType = "Defense", card[19].typeNo = 2, card[19].cardAttribute = "Shield", card[19].attributeCode = 1;
	card[20].cardCode = 20, card[20].cardsName = "Firewall", card[20].cardType = "Defense", card[20].typeNo = 2, card[20].cardAttribute = "Lock", card[20].attributeCode = 2;
	card[21].cardCode = 21, card[21].cardsName = "Firewall", card[21].cardType = "Defense", card[21].typeNo = 2, card[21].cardAttribute = "Lock", card[21].attributeCode = 2;
	card[22].cardCode = 22, card[22].cardsName = "Firewall", card[22].cardType = "Defense", card[22].typeNo = 2, card[22].cardAttribute = "Lock", card[22].attributeCode = 2;
	card[23].cardCode = 23, card[23].cardsName = "Firewall", card[23].cardType = "Defense", card[23].typeNo = 2, card[23].cardAttribute = "Lock", card[23].attributeCode = 2;
	card[24].cardCode = 24, card[24].cardsName = "Encryption", card[24].cardType = "Defense", card[24].typeNo = 2, card[24].cardAttribute = "Wireless", card[24].attributeCode = 3;
	card[25].cardCode = 25, card[25].cardsName = "Encryption", card[25].cardType = "Defense", card[25].typeNo = 2, card[25].cardAttribute = "Wireless", card[25].attributeCode = 3;
	card[26].cardCode = 26, card[26].cardsName = "Encryption", card[26].cardType = "Defense", card[26].typeNo = 2, card[26].cardAttribute = "Wireless", card[26].attributeCode = 3;
	card[27].cardCode = 27, card[27].cardsName = "Encryption", card[27].cardType = "Defense", card[27].typeNo = 2, card[27].cardAttribute = "Wireless", card[27].attributeCode = 3;
	card[28].cardCode = 28, card[28].cardsName = "Education", card[28].cardType = "Defense", card[28].typeNo = 2, card[28].cardAttribute = "House", card[28].attributeCode = 4;
	card[29].cardCode = 29, card[29].cardsName = "Education", card[29].cardType = "Defense", card[29].typeNo = 2, card[29].cardAttribute = "House", card[29].attributeCode = 4;
	card[30].cardCode = 30, card[30].cardsName = "Education", card[30].cardType = "Defense", card[30].typeNo = 2, card[30].cardAttribute = "House", card[30].attributeCode = 4;
	card[31].cardCode = 31, card[31].cardsName = "Education", card[31].cardType = "Defense", card[31].typeNo = 2, card[31].cardAttribute = "House", card[31].attributeCode = 4;

	card[32].cardCode = 32, card[32].cardsName = "Malware", card[32].cardType = "Attack", card[32].typeNo = 3, card[32].cardAttribute = "Shield", card[32].attributeCode = 1;
	card[33].cardCode = 33, card[33].cardsName = "Malware", card[33].cardType = "Attack", card[33].typeNo = 3, card[33].cardAttribute = "Shield", card[33].attributeCode = 1;
	card[34].cardCode = 34, card[34].cardsName = "Malware", card[34].cardType = "Attack", card[34].typeNo = 3, card[34].cardAttribute = "Shield", card[34].attributeCode = 1;
	card[35].cardCode = 35, card[35].cardsName = "Malware", card[35].cardType = "Attack", card[35].typeNo = 3, card[35].cardAttribute = "Shield", card[35].attributeCode = 1;
	card[36].cardCode = 36, card[36].cardsName = "Hacker", card[36].cardType = "Attack", card[36].typeNo = 3, card[36].cardAttribute = "Lock", card[36].attributeCode = 2;
	card[37].cardCode = 37, card[37].cardsName = "Hacker", card[37].cardType = "Attack", card[37].typeNo = 3, card[37].cardAttribute = "Lock", card[37].attributeCode = 2;
	card[38].cardCode = 38, card[38].cardsName = "Hacker", card[38].cardType = "Attack", card[38].typeNo = 3, card[38].cardAttribute = "Lock", card[38].attributeCode = 2;
	card[39].cardCode = 39, card[39].cardsName = "Hacker", card[39].cardType = "Attack", card[39].typeNo = 3, card[39].cardAttribute = "Lock", card[39].attributeCode = 2;
	card[40].cardCode = 40, card[40].cardsName = "Wireless_Attack", card[40].cardType = "Attack", card[40].typeNo = 3, card[40].cardAttribute = "Wireless", card[40].attributeCode = 3;
	card[41].cardCode = 41, card[41].cardsName = "Wireless_Attack", card[41].cardType = "Attack", card[41].typeNo = 3, card[41].cardAttribute = "Wireless", card[41].attributeCode = 3;
	card[42].cardCode = 42, card[42].cardsName = "Wireless_Attack", card[42].cardType = "Attack", card[42].typeNo = 3, card[42].cardAttribute = "Wireless", card[42].attributeCode = 3;
	card[43].cardCode = 43, card[43].cardsName = "Wireless_Attack", card[43].cardType = "Attack", card[43].typeNo = 3, card[43].cardAttribute = "Wireless", card[43].attributeCode = 3;
	card[44].cardCode = 44, card[44].cardsName = "Phishing", card[44].cardType = "Attack", card[44].typeNo = 3, card[44].cardAttribute = "House", card[44].attributeCode = 4;
	card[45].cardCode = 45, card[45].cardsName = "Phishing", card[45].cardType = "Attack", card[45].typeNo = 3, card[45].cardAttribute = "House", card[45].attributeCode = 4;
	card[46].cardCode = 46, card[46].cardsName = "Phishing", card[46].cardType = "Attack", card[46].typeNo = 3, card[46].cardAttribute = "House", card[46].attributeCode = 4;
	card[47].cardCode = 47, card[47].cardsName = "Phishing", card[47].cardType = "Attack", card[47].typeNo = 3, card[47].cardAttribute = "House", card[47].attributeCode = 4;
	card[48].cardCode = 48, card[48].cardsName = "Cyber_Attack", card[48].cardType = "Attack", card[48].typeNo = 3, card[48].cardAttribute = "All", card[48].attributeCode = 5;
	card[49].cardCode = 49, card[49].cardsName = "Cyber_Attack", card[49].cardType = "Attack", card[49].typeNo = 3, card[49].cardAttribute = "All", card[49].attributeCode = 5;

}

int startGame()
{
	cout << "Welcome to the cyber security Game!!" << endl <<
		"If you press 1, then you will start the game!" << endl << "If you press 2, then you will quit!!" << endl;

	int number;

	cout << "You press: ";
	cin >> number;

	bool progress = 1;

	while (progress)
	{
		if (number == 1)
			return progress;
		else if (number == 2)
		{
			progress = 0;
			return progress;
		}
		else
		{
			cout << endl << "Press 1 or 2!! " << endl;
			cout << "You press: ";
			cin >> number;
		}
	}

	return -1;
}

void incrementTurn(int& turn)
{
	turn++;
}

int makingChoice()
{
	int num;
	cin >> num;

	return num;
}

vector<int> gameInProgress(vector<int> deck, bool mode)
{
	cout << endl << endl << "The game has been started!!!" << endl;

	vector<int> player2Asset{ 99, 99, 99, 99, 99, 99, 99, 99, 99 };
	vector<int> player2Defense{ 99, 99, 99, 99, 99, 99, 99, 99, 99 };
	vector<int> Attack{ 99, 99, 99, 99, 99, 99, 99, 99, 99 };
	vector<int> player1Defense{ 99, 99, 99, 99, 99, 99, 99, 99, 99 };
	vector<int> player1Asset{ 99, 99, 99, 99, 99, 99, 99, 99, 99 };

	vector<bool> player2DefenseAvailability{ false, false, false, false, false, false, false, false, false };
	vector<bool> player1DefenseAvailability{ false, false, false, false, false, false, false, false, false };

	vector<bool> player2AssetAvailability{ true, true, true, true, true, true, true, true, true };
	vector<bool> player1AssetAvailability{ true, true, true, true, true, true, true, true, true };

	int currentTurn = -1;

	while (currentTurn < 49)
	{
		incrementTurn(currentTurn);

		creatGameTable(player2Asset, player2Defense, Attack, player1Defense, player1Asset);

		if (currentTurn % 2 == 0) // Player1's turn
		{
			showCardsInfos(currentTurn, deck);

			if (card[deck[currentTurn]].typeNo == 1)
				blueCard(player1Asset, player1AssetAvailability, deck, currentTurn, player1DefenseAvailability);
			else if (card[deck[currentTurn]].typeNo == 2)
				greenCard(player1Asset, deck, player1DefenseAvailability, player1Defense, currentTurn);
			else
				redCard(player2Asset, deck, player2Defense, player2AssetAvailability, player2DefenseAvailability, currentTurn);
		}
		else // Player2's turn // AI's turn when mode is true
		{
			showCardsInfos(currentTurn, deck);

			if (card[deck[currentTurn]].typeNo == 1)
				blueCard(player2Asset, player2AssetAvailability, deck, currentTurn, player2DefenseAvailability);
			else if (card[deck[currentTurn]].typeNo == 2)
				greenCard(player2Asset, deck, player2DefenseAvailability, player2Defense, currentTurn);
			else
				redCard(player1Asset, deck, player1Defense, player1AssetAvailability, player1DefenseAvailability, currentTurn);
		}
	}

	vector<int> result;

	getGameResult(player1Asset, player2Asset, result);

	return result;
}

void showResult(vector<int> happy)
{
	cout << "---------------Result--------------------" << endl;
	cout << "Player1 got " << happy[0] << " cards" << endl;
	cout << "Player2 got " << happy[1] << " cards" << endl;
	cout << "-----------------------------------------" << endl << endl;

	if (happy[0] > happy[1])
		cout << "Player 1 Won!!!" << endl << "Congratulation!";
	else if (happy[0] == happy[1])
		cout << "Draw!!";
	else
		cout << "Player 2 Won!!!" << endl << "Congratulation!";

	cout << endl << endl << "See you next Time!" << endl;
}

void creatGameTable(vector<int> vec1, vector<int> vec2, vector<int> vec3, vector<int> vec4, vector<int> vec5)
{
	cout << "*Player2 Side*" << endl;
	cout << "Asset   [ " << setw(2) << vec1[0] << " ] " << "[ " << setw(2) << vec1[1] << " ] " << "[ " << setw(2) << vec1[2] << " ] " << "[ " << setw(2) << vec1[3] << " ] "
		<< "[ " << setw(2) << vec1[4] << " ] " << "[ " << setw(2) << vec1[5] << " ] " << "[ " << setw(2) << vec1[6] << " ] " << "[ " << setw(2) << vec1[7] << " ] " << "[ " << setw(2) << vec1[8] << " ] " << endl;
	cout << "Defense [ " << setw(2) << vec2[0] << " ] " << "[ " << setw(2) << vec2[1] << " ] " << "[ " << setw(2) << vec2[2] << " ] " << "[ " << setw(2) << vec2[3] << " ] "
		<< "[ " << setw(2) << vec2[4] << " ] " << "[ " << setw(2) << vec2[5] << " ] " << "[ " << setw(2) << vec2[6] << " ] " << "[ " << setw(2) << vec2[7] << " ] " << "[ " << setw(2) << vec2[8] << " ] " << endl;
	cout << "Attack  [ " << setw(2) << vec3[0] << " ] " << "[ " << setw(2) << vec3[1] << " ] " << "[ " << setw(2) << vec3[2] << " ] " << "[ " << setw(2) << vec3[3] << " ] "
		<< "[ " << setw(2) << vec3[4] << " ] " << "[ " << setw(2) << vec3[5] << " ] " << "[ " << setw(2) << vec3[6] << " ] " << "[ " << setw(2) << vec3[7] << " ] " << "[ " << setw(2) << vec3[8] << " ] " << endl;
	cout << "Defens  [ " << setw(2) << vec4[0] << " ] " << "[ " << setw(2) << vec4[1] << " ] " << "[ " << setw(2) << vec4[2] << " ] " << "[ " << setw(2) << vec4[3] << " ] "
		<< "[ " << setw(2) << vec4[4] << " ] " << "[ " << setw(2) << vec4[5] << " ] " << "[ " << setw(2) << vec4[6] << " ] " << "[ " << setw(2) << vec4[7] << " ] " << "[ " << setw(2) << vec4[8] << " ] " << endl;
	cout << "Asset   [ " << setw(2) << vec5[0] << " ] " << "[ " << setw(2) << vec5[1] << " ] " << "[ " << setw(2) << vec5[2] << " ] " << "[ " << setw(2) << vec5[3] << " ] "
		<< "[ " << setw(2) << vec5[4] << " ] " << "[ " << setw(2) << vec5[5] << " ] " << "[ " << setw(2) << vec5[6] << " ] " << "[ " << setw(2) << vec5[7] << " ] " << "[ " << setw(2) << vec5[8] << " ] " << endl;
	cout << "*Player1 Side*" << endl << endl << endl;
}

void showCardsInfos(int& currentTurn, vector<int>& deck)
{
	cout << "<< Player" << (currentTurn % 2 + 1) << "\'s Turn >> Current Turn: " << currentTurn + 1 << endl << endl;
	cout << "The card you drew this turn: "
		<< endl << "Card Number:   " << card[deck[currentTurn]].cardCode
		<< endl << "Name:          " << card[deck[currentTurn]].cardsName
		<< endl << "Card Type:     " << card[deck[currentTurn]].cardType // color
		<< endl << "cardAttribute: " << card[deck[currentTurn]].cardAttribute << endl; // attribute
}

void blueCard(vector<int>& playerAsset, vector<bool>& playerAssetAvailability, vector<int>& deck, int& currentTurn, vector<bool>& playerDefenseAvailability)
{
	int choice;

	cout << "You have choices of position such that: ";

	for (unsigned int i = 0; i < playerAsset.size(); i++)
	{
		if ((playerAssetAvailability[i]) == true)
			cout << i << " ";
	}
	cout << endl;

	cout << "Where do you want to put your card?" << endl;
	cout << "Your choice of position is: " << endl;
	choice = makingChoice();
	playerAsset[choice] = card[deck[currentTurn]].cardCode;
	playerAssetAvailability[choice] = false;
	playerDefenseAvailability[choice] = true;
}

void greenCard(vector<int>& playerAsset, vector<int>& deck, vector<bool>& playerDefenseAvailability, vector<int>& playerDefense, int& currentTurn)
{
	vector<int> available;

	greenCard_detectBlueCards(playerAsset, playerDefenseAvailability, deck, currentTurn, available);
	greenCard_makingDecisions(available, playerDefense, deck, playerDefenseAvailability, currentTurn);

	available.clear();
}

void greenCard_detectBlueCards(vector<int>& playerAsset, vector<bool>& playerDefenseAvailability, vector<int>& deck, int& currentTurn, vector<int>& available)
{
	for (int i = 0; i < 8; i++)
		if (playerAsset[i] != 99) // if there is a card on the n th slot on blue area
			if ((card[deck[currentTurn]].cardAttribute == card[playerAsset[i]].cardAttribute) && playerDefenseAvailability[i])
				available.push_back(i); // store the position of the card
}

void greenCard_makingDecisions(vector<int>& available, vector<int>& playerDefense, vector<int>& deck, vector<bool>& playerDefenseAvailability, int& currentTurn)
{
	int choice;

	if (available.size() != 0)
	{
		cout << "Where do you want to put your card?" << endl;
		cout << "You have choices of position such that: ";
		for (unsigned int i = 0; i < available.size(); i++)
			cout << available[i] << "  ";
		cout << endl << "Your choice of position is: " << endl;
		choice = makingChoice();
		playerDefense[choice] = card[deck[currentTurn]].cardCode; // place the card
		playerDefenseAvailability[choice] = false;
	}
	else
	{
		cout << "You do not have any choice to put your card!!" << endl << endl;
		wasteCard();
	}
}

void redCard(vector<int>& playerAsset, vector<int>& deck, vector<int>& playerDefense, vector<bool>& playerAssetAvailability, vector<bool>& playerDefenseAvailability, int& currentTurn)
{
	vector<int> deleteableAsset;
	vector<int> deleteableDefense;

	redCard_detectBlueCards(playerAsset, deleteableAsset, deck, currentTurn);

	cout << "deletableasset size: " << deleteableAsset.size() << endl;

	if (deleteableAsset.size() == 0) // if theres no asset card
	{
		cout << "You do not have any choice to attack opponent's card!!" << endl << endl; // end the turn
		wasteCard();
		return;
	}
	else // if theres asset card to delete
	{
		cout << "Choose the position that you want to attack!!" << endl << "You can choose " << endl;

		int choice;

		for (unsigned int i = 0; i < deleteableAsset.size(); i++)
			cout << deleteableAsset[i] << " ";

		cout << endl << "Your choice is: ";

		choice = makingChoice();

		if (playerDefense[choice] == 99) // if there is not green card in front of the blue card
			redCard_finallyAttackBlue(playerAsset, playerAssetAvailability, choice);
		else // if there is green card in front of the blue card
			redCard_finallyAttackGreen(playerDefense, playerDefenseAvailability, choice);

		deleteableAsset.clear();
		deleteableDefense.clear();
	}
}

void redCard_detectBlueCards(vector<int>& playerAsset, vector<int>& deleteableAsset, vector<int>& deck, int& currentTurn)
{
	for (unsigned int i = 0; i < playerAsset.size(); i++) // check deletable asset cards
	{
		if (playerAsset[i] != 99)
			if (((card[playerAsset[i]].attributeCode == card[deck[currentTurn]].attributeCode)))
				deleteableAsset.push_back(i);
			else if ((card[deck[currentTurn]].attributeCode == 5))
				deleteableAsset.push_back(i);
	}
}

void redCard_detectDeletableBlue(vector<int>& playerDefense, vector<int>& deck, int& currentTurn, vector<int>& deleteableDefense)
{
	for (unsigned int i = 0; i < playerDefense.size(); i++) // check deletable asset cards
	{
		if ((playerDefense[i] != 99) && (card[playerDefense[i]].attributeCode == card[deck[currentTurn]].attributeCode))
			deleteableDefense.push_back(i);
		else if ((playerDefense[i] != 99) && (card[deck[currentTurn]].attributeCode == 5))
			deleteableDefense.push_back(i);
	}
}

void redCard_finallyAttackGreen(vector<int>& playerDefense, vector<bool>& playerDefenseAvailability, int& choice)
{
	playerDefense[choice] = 99;
	playerDefenseAvailability[choice] = true;
}

void redCard_finallyAttackBlue(vector<int>& playerAsset, vector<bool>& playerAssetAvailability, int& choice)
{
	playerAsset[choice] = 99;
	playerAssetAvailability[choice] = true;
}

vector<int> getGameResult(vector<int>& player1Asset, vector<int>& player2Asset, vector<int>& result)
{
	int p1Result = 0, p2Result = 0;

	for (unsigned int i = 0; i < player1Asset.size(); i++)
	{
		if (player1Asset[i] != 99)
			p1Result++;
	}
	for (unsigned int i = 0; i < player2Asset.size(); i++)
	{
		if (player2Asset[i] != 99)
			p2Result++;
	}

	result.push_back(p1Result);
	result.push_back(p2Result);

	return result;
}

void wasteCard()
{
	string word;

	cout << "Type \"w\" to throw your card away: ";
	cin >> word;

	while (word != "w")
	{
		cout << endl;
		cout << "Type \"w\" to throw your card away: ";
		cin >> word;
	}
}

bool enableAImode(int num)
{
	if (num == 1) // p v p
		return false;
	else // p v ai
		return true;
}
