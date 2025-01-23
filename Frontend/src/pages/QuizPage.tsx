import React, { useEffect, useState } from "react";
import { getQuizQuestions, submitAnswers } from "../api/quizApi";
import { QuizQuestionResponseDTO } from "../types/types";
import { Button, TextField, Typography, Stepper, Step, StepLabel } from "@mui/material";
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
  const [activeStep, setActiveStep] = useState(0);
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

  const handleNext = (e: React.FormEvent) => {
    e.preventDefault();
    setActiveStep((prevStep) => prevStep + 1);
  };

  const handleBack = () => {
    setActiveStep((prevStep) => prevStep - 1);
  };

  return (
    <form onSubmit={handleSubmit}>
      <Typography variant="h4" gutterBottom sx={{ fontWeight: 600 }}>
        General Knowledge Quiz
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

          <Stepper activeStep={activeStep} alternativeLabel sx={{ marginBottom: "20px" }}>
            {questions.map((question, index) => (
              <Step key={question.id}>
                <StepLabel
                  sx={{
                    whiteSpace: "nowrap",
                    overflow: "hidden",
                    textOverflow: "ellipsis",
                  }}
                >
                  {`Question ${index + 1}`}
                </StepLabel>
              </Step>
            ))}
          </Stepper>

          {questions.length > 0 && (
            <div>
              {activeStep < questions.length ? (
                <>
                  {questions[activeStep].questionType === "radio" && (
                    <RadioQuestion
                      key={questions[activeStep].id}
                      questionId={questions[activeStep].id}
                      question={questions[activeStep].question}
                      options={questions[activeStep].options}
                      handleChange={handleChange}
                    />
                  )}

                  {questions[activeStep].questionType === "checkbox" && (
                    <CheckboxQuestion
                      key={questions[activeStep].id}
                      questionId={questions[activeStep].id}
                      question={questions[activeStep].question}
                      options={questions[activeStep].options}
                      answers={answers}
                      handleChange={handleChange}
                    />
                  )}

                  {questions[activeStep].questionType === "textbox" && (
                    <TextBoxQuestion
                      key={questions[activeStep].id}
                      questionId={questions[activeStep].id}
                      question={questions[activeStep].question}
                      handleChange={handleChange}
                    />
                  )}

                  <div>
                    <Button
                      disabled={activeStep === 0}
                      onClick={handleBack}
                      variant="outlined"
                      sx={{ marginRight: 2 }}
                    >
                      Back
                    </Button>
                    {activeStep === questions.length - 1 ? (
                      <Button type="submit" variant="contained" color="primary">
                        Submit
                      </Button>
                    ) : (
                      <Button onClick={handleNext} variant="contained" color="primary">
                        Next
                      </Button>
                    )}
                  </div>
                </>
              ) : null}
            </div>
          )}
        </>
      )}
    </form>
  );
};

export default QuizPage;
