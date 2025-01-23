import React, { useEffect, useState } from "react";
import { getQuizQuestions, submitAnswers } from "../api/quizApi";
import { QuizQuestionResponseDTO } from "../types/types";
import {
  Button,
  TextField,
  FormControlLabel,
  Checkbox,
  Radio,
  RadioGroup,
  FormLabel,
  Typography,
} from "@mui/material";
import { useNavigate } from "react-router-dom";

const QuizPage: React.FC = () => {
  const [questions, setQuestions] = useState<QuizQuestionResponseDTO[]>([]);
  const [answers, setAnswers] = useState<Record<string, string[]>>({});
  const [email, setEmail] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const fetchQuestions = async () => {
      const data = await getQuizQuestions();
      setQuestions(data);
    };
    fetchQuestions();
  }, []);

  const handleChange = (questionId: number, value: string | string[]) => {
    setAnswers((prev) => ({
      ...prev,
      [questionId]: Array.isArray(value) ? value : [value],
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const score = await submitAnswers(email, answers);
    alert(`Your score is: ${score}`);
    navigate("/highscores");
  };

  return (
    <form onSubmit={handleSubmit}>
      <Typography variant="h4">General Knowledge Quiz (10 questions)</Typography>
      <TextField
        label="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        required
        fullWidth
        margin="normal"
      />
      {questions.map((question) => (
        <div key={question.id}>
          <FormLabel>{question.question}</FormLabel>
          {question.questionType === "radio" && (
            <RadioGroup onChange={(e) => handleChange(question.id, e.target.value)}>
              {question.options.map((option) => (
                <FormControlLabel key={option} control={<Radio />} label={option} value={option} />
              ))}
            </RadioGroup>
          )}
          {question.questionType === "checkbox" && (
            <>
              {question.options.map((option) => (
                <FormControlLabel
                  key={option}
                  control={
                    <Checkbox
                      onChange={(e) => {
                        const value = e.target.checked
                          ? [...(answers[question.id] || []), option]
                          : (answers[question.id] || []).filter((ans) => ans !== option);
                        handleChange(question.id, value);
                      }}
                    />
                  }
                  label={option}
                />
              ))}
            </>
          )}
          {question.questionType === "textbox" && (
            <TextField
              onChange={(e) => handleChange(question.id, e.target.value)}
              fullWidth
              margin="normal"
            />
          )}
        </div>
      ))}
      <Button type="submit" variant="contained" color="primary">
        Submit
      </Button>
    </form>
  );
};

export default QuizPage;
