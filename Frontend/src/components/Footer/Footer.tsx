import SocialIcons from "./SocialIcons";
import "./Footer.css";

const Footer = () => {
  return (
    <footer className="footer">
      <div className="footer-text">
        © {new Date().getFullYear()} Aurimas Dabrišius. Internship task for Present Connection.
      </div>
      <SocialIcons />
    </footer>
  );
};

export default Footer;
