import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Quiz from "./components/Quiz";
import HighScores from "./components/HighScores";
import { Container } from "@mui/material";

const App: React.FC = () => {
  return (
    <Router>
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
