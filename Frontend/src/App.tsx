import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { CssBaseline } from "@mui/material";
import Header from "./components/Header/Header";
import Content from "./components/Content/Content.tsx";
import Footer from "./components/Footer/Footer.tsx";
import Quiz from "./pages/Quiz";
import HighScores from "./pages/HighScores";
import "./App.css";

const App: React.FC = () => {
  return (
    <div className="App">
      <CssBaseline />
      <Router>
        <Header />
        <Content>
          <Routes>
            <Route path="/" element={<Quiz />} />
            <Route path="/highscores" element={<HighScores />} />
          </Routes>
        </Content>
        <Footer />
      </Router>
    </div>
  );
};

export default App;
