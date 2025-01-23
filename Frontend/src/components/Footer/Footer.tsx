import { FaGithub, FaTwitter, FaInstagram, FaLinkedin } from "react-icons/fa";
import "./Footer.css";

const Footer = () => {
  return (
    <footer className="footer">
      <div className="footer-text">
        © {new Date().getFullYear()} Aurimas Dabrišius. Internship task for Present Connection.
      </div>
      <div className="social-icons">
        <a
          href="https://www.linkedin.com/in/aurimas-dabrišius"
          target="_blank"
          rel="noopener noreferrer"
        >
          <FaLinkedin />
        </a>
        <a href="https://github.com/AurisTFG" target="_blank" rel="noopener noreferrer">
          <FaGithub />
        </a>
        <a href="https://x.com/AurisTFG" target="_blank" rel="noopener noreferrer">
          <FaTwitter />
        </a>
        <a href="https://www.instagram.com/auristfg" target="_blank" rel="noopener noreferrer">
          <FaInstagram />
        </a>
      </div>
    </footer>
  );
};

export default Footer;
