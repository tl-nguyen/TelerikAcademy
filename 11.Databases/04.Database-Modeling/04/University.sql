SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema University
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `University` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `University` ;

-- -----------------------------------------------------
-- Table `University`.`Student`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Student` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Faculty`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Faculty` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Department`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Department` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `Faculty_id` INT NOT NULL,
  PRIMARY KEY (`id`, `Faculty_id`),
  INDEX `fk_Department_Faculty1_idx` (`Faculty_id` ASC),
  CONSTRAINT `fk_Department_Faculty1`
    FOREIGN KEY (`Faculty_id`)
    REFERENCES `University`.`Faculty` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Professor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Professor` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `Department_id` INT NOT NULL,
  PRIMARY KEY (`id`, `Department_id`),
  INDEX `fk_Professor_Department_idx` (`Department_id` ASC),
  CONSTRAINT `fk_Professor_Department`
    FOREIGN KEY (`Department_id`)
    REFERENCES `University`.`Department` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Course`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Course` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `Department_id` INT NOT NULL,
  PRIMARY KEY (`id`, `Department_id`),
  INDEX `fk_Course_Department1_idx` (`Department_id` ASC),
  CONSTRAINT `fk_Course_Department1`
    FOREIGN KEY (`Department_id`)
    REFERENCES `University`.`Department` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Title`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Title` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`ProfessorTitle`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`ProfessorTitle` (
  `Professor_id` INT NOT NULL,
  `Title_id` INT NOT NULL,
  PRIMARY KEY (`Professor_id`, `Title_id`),
  INDEX `fk_ProfessorTitle_Professor1_idx` (`Professor_id` ASC),
  INDEX `fk_ProfessorTitle_Title1_idx` (`Title_id` ASC),
  CONSTRAINT `fk_ProfessorTitle_Professor1`
    FOREIGN KEY (`Professor_id`)
    REFERENCES `University`.`Professor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorTitle_Title1`
    FOREIGN KEY (`Title_id`)
    REFERENCES `University`.`Title` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`StudentCourse`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`StudentCourse` (
  `Student_id` INT NOT NULL,
  `Course_id` INT NOT NULL,
  PRIMARY KEY (`Student_id`, `Course_id`),
  INDEX `fk_StudentCourse_Student1_idx` (`Student_id` ASC),
  INDEX `fk_StudentCourse_Course1_idx` (`Course_id` ASC),
  CONSTRAINT `fk_StudentCourse_Student1`
    FOREIGN KEY (`Student_id`)
    REFERENCES `University`.`Student` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_StudentCourse_Course1`
    FOREIGN KEY (`Course_id`)
    REFERENCES `University`.`Course` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
