import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Quiz from "./pages/Quiz";
import HighScores from "./pages/HighScores";
import { Container } from "@mui/material";
import Header from "./components/Header/Header";

const App: React.FC = () => {
  return (
    <Router>
      <Header />
      <Container>
        <Routes>
          <Route path="/" element={<Quiz />} />
          <Route path="/highscores" element={<HighScores />} />
        </Routes>
      </Container>
    </Router>
  );
};

export default App;
