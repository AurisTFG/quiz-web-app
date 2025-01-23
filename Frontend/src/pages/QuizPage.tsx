import React, { useEffect, useState } from "react";
import { getQuizQuestions, submitAnswers } from "../api/quizApi";
import { QuizQuestionResponseDTO } from "../types/types";
import { Button, TextField, Typography } from "@mui/material";
import RadioQuestion from "../components/Quiz/RadioQuestion";
import CheckboxQuestion from "../components/Quiz/CheckboxQuestion";
import TextBoxQuestion from "../components/Quiz/TextBoxQuestion";
import Spinner from "../components/Spinner/Spinner";
import { useNavigate } from "react-router-dom";

const QuizPage: React.FC = () => {
  const [loading, setLoading] = useState(true);
  const [questions, setQuestions] = useState<QuizQuestionResponseDTO[]>([]);
  const [answers, setAnswers] = useState<Record<string, string[]>>({});
  const [email, setEmail] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const fetchQuestions = async () => {
      const data = await getQuizQuestions();
      setQuestions(data);
      setLoading(false);
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
      <Typography variant="h4" gutterBottom sx={{ fontWeight: 600 }}>
        General Knowledge Quiz
      </Typography>
      <Typography variant="h6" gutterBottom>
        (10 questions)
      </Typography>
      {loading ? (
        <Spinner />
      ) : (
        <>
          <TextField
            label="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
            fullWidth
            margin="normal"
            sx={{
              marginBottom: "20px",
              "& .MuiOutlinedInput-root": {
                borderRadius: "8px",
                backgroundColor: "#f9f9f9",
              },
            }}
          />

          {questions.map((question) => {
            if (question.questionType === "radio") {
              return (
                <RadioQuestion
                  key={question.id}
                  questionId={question.id}
                  question={question.question}
                  options={question.options}
                  handleChange={handleChange}
                />
              );
            }

            if (question.questionType === "checkbox") {
              return (
                <CheckboxQuestion
                  key={question.id}
                  questionId={question.id}
                  question={question.question}
                  options={question.options}
                  answers={answers}
                  handleChange={handleChange}
                />
              );
            }

            if (question.questionType === "textbox") {
              return (
                <TextBoxQuestion
                  key={question.id}
                  questionId={question.id}
                  question={question.question}
                  handleChange={handleChange}
                />
              );
            }

            return null;
          })}
          <Button type="submit" variant="contained" color="primary">
            Submit
          </Button>
        </>
      )}
    </form>
  );
};

export default QuizPage;
