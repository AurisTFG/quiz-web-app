import React, { useEffect, useState } from "react";
import { getQuizQuestions, submitAnswers } from "../api/quizApi";
import { QuizQuestionResponseDTO } from "../types/types";
import QuizForm from "../components/Quiz/QuizForm";
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
    <QuizForm
      loading={loading}
      questions={questions}
      answers={answers}
      email={email}
      setEmail={setEmail}
      handleChange={handleChange}
      handleSubmit={handleSubmit}
    />
  );
};

export default QuizPage;
