# The Beast at the Back – BlockDAG Hackathon

An **endless runner horror game** with a **cartoony aesthetic** where a mysterious beast chases you endlessly.  
Avoid obstacles, survive as long as possible, and **submit your high scores on-chain** to the BlockDAG Primordial Testnet!

---

## 🎮 How to Play

- **PC/Mobile Controls**  
  - Tap / Spacebar → **Jump**  
  - Avoid **rocks & traps**  
  - Survive as long as you can!

- **If you hit an obstacle or get caught by the beast → Game Over**
  - A **jumpscare** will appear 😱  
  - Your score is shown on the Game Over screen  

- After Game Over → You’ll be redirected to the **Leaderboard Page**  
  - Connect **MetaMask**  
  - Enter your **username**  
  - Submit your **score to the blockchain**  

---

## 🌐 Play Online  

- **WebGL Build Link** (hosted version):  
  [Play on GitHub Pages](https://midhanraj.github.io/TheBeastAtTheBack_BlockDAG/WebGL_Build/)  

- **Leaderboard & Wallet Connect Page**:  
  [View Leaderboard](https://midhanraj.github.io/TheBeastAtTheBack_BlockDAG/Leaderboard_Web/Leaderboard.html)  

---

## ✨ Features  

✅ Endless Runner gameplay with cartoony horror style  
✅ **Touch & keyboard controls** for mobile & desktop  
✅ **On-chain leaderboard** using BDAG smart contracts  
✅ MetaMask wallet integration  
✅ **Highest score logic** → only your **best score** is stored  
✅ Jumpscare screen when you lose  

---

## 📜 Smart Contract  

- **Network:** BlockDAG Primordial Testnet  
- **Contract Address:** `0x7b41e89fd20bec81adbaad81c7e0ee2bd409f402`  
- **Features:**  
  - One entry per player  
  - Updates **only if new score is higher than previous**  
  - Stores `address + username + highestScore`  

---

## 🛠️ Installation  

To run locally:  

```bash
git clone https://github.com/MidhanRaj/TheBeastAtTheBack_BlockDAG.git
cd TheBeastAtTheBack_BlockDAG/WebGL_Build
open index.html
