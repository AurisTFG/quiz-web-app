import React from "react";
import { FaGithub, FaTwitter, FaInstagram, FaLinkedin } from "react-icons/fa";

interface SocialLink {
  href: string;
  icon: JSX.Element;
}

const SocialIcons: React.FC = () => {
  const socialLinks: SocialLink[] = [
    { href: "https://www.linkedin.com/in/aurimas-dabrišius", icon: <FaLinkedin /> },
    { href: "https://github.com/AurisTFG", icon: <FaGithub /> },
    { href: "https://x.com/AurisTFG", icon: <FaTwitter /> },
    { href: "https://www.instagram.com/auristfg", icon: <FaInstagram /> },
  ];

  return (
    <div className="social-icons">
      {socialLinks.map((link, index) => (
        <a key={index} href={link.href} target="_blank" rel="noopener noreferrer">
          {link.icon}
        </a>
      ))}
    </div>
  );
};

export default SocialIcons;
