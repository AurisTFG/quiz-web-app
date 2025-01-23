import React from "react";
import { Button } from "@mui/material";
import { Link } from "react-router-dom";
import { useLocation } from "react-router-dom";

interface NavButtonProps {
  to: string;
  label: string;
}

const NavButtons: React.FC = () => {
  const location = useLocation();
  const isActive = (path: string) => location.pathname === path;

  const buttons: NavButtonProps[] = [
    { to: "/", label: "Quiz" },
    { to: "/highscores", label: "High Scores" },
  ];

  return (
    <>
      {buttons.map((button, index) => (
        <Button
          key={index}
          color="inherit"
          component={Link}
          to={button.to}
          sx={{
            mr: 1,
            textDecoration: isActive(button.to) ? "underline" : "none",
            fontSize: "1.20rem",
          }}
        >
          {button.label}
        </Button>
      ))}
    </>
  );
};

export default NavButtons;
