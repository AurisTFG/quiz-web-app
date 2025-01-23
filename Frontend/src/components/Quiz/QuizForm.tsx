import React from "react";
import { Button, TextField, Typography } from "@mui/material";
import { QuizQuestionResponseDTO } from "../../types/types";
import RadioQuestion from "./RadioQuestion";
import CheckboxQuestion from "./CheckboxQuestion";
import TextBoxQuestion from "./TextBoxQuestion";
import Spinner from "../Spinner/Spinner";

interface QuizFormProps {
  loading: boolean;
  questions: QuizQuestionResponseDTO[];
  answers: Record<string, string[]>;
  email: string;
  setEmail: React.Dispatch<React.SetStateAction<string>>;
  handleChange: (questionId: number, value: string | string[]) => void;
  handleSubmit: (e: React.FormEvent) => void;
}

const QuizForm: React.FC<QuizFormProps> = ({
  loading,
  questions,
  answers,
  email,
  setEmail,
  handleChange,
  handleSubmit,
}) => {
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

export default QuizForm;
