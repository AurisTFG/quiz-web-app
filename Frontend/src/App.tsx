import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { CssBaseline } from "@mui/material";
import Header from "./components/Header/Header";
import Content from "./components/Content/Content.tsx";
import Footer from "./components/Footer/Footer.tsx";
import QuizPage from "./pages/QuizPage.tsx";
import HighScoresPage from "./pages/HighScoresPage.tsx";
import "./App.css";

const App: React.FC = () => {
  return (
    <div className="App">
      <CssBaseline />
      <Router>
        <Header />
        <Content>
          <Routes>
            <Route path="/" element={<QuizPage />} />
            <Route path="/highscores" element={<HighScoresPage />} />
          </Routes>
        </Content>
        <Footer />
      </Router>
    </div>
  );
};

export default App;
