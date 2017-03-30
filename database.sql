/*
SQLyog Enterprise v12.08 (64 bit)
MySQL - 5.6.34 : Database - usersystem
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`usersystem` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `usersystem`;

/*Table structure for table `ls_authority` */

DROP TABLE IF EXISTS `ls_authority`;

CREATE TABLE `ls_authority` (
  `AuthorityId` int(11) NOT NULL AUTO_INCREMENT,
  `IsDelete` bit(1) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  `Name` varchar(128) NOT NULL,
  `Status` varchar(32) NOT NULL DEFAULT 'ACTIVE',
  `PorityLevel` int(11) NOT NULL DEFAULT '0',
  `Permission` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`AuthorityId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

/*Data for the table `ls_authority` */

insert  into `ls_authority`(`AuthorityId`,`IsDelete`,`CreateDate`,`ModifyDate`,`CreateByUserId`,`ModifyByUserId`,`Name`,`Status`,`PorityLevel`,`Permission`) values (6,'\0','2016-11-15 11:44:13',NULL,NULL,NULL,'??-randy','ACTIVE',0,NULL),(7,'\0','2016-11-15 11:48:07',NULL,NULL,NULL,'??-randy','ACTIVE',0,NULL);

/*Table structure for table `ls_company` */

DROP TABLE IF EXISTS `ls_company`;

CREATE TABLE `ls_company` (
  `CompanyId` int(11) NOT NULL AUTO_INCREMENT,
  `CreateDate` datetime NOT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `Status` varchar(32) NOT NULL DEFAULT 'ACTIVE',
  `Code` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0',
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  `Icon` varchar(256) DEFAULT NULL,
  `Link` text,
  PRIMARY KEY (`CompanyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `ls_company` */

/*Table structure for table `ls_department` */

DROP TABLE IF EXISTS `ls_department`;

CREATE TABLE `ls_department` (
  `DepartmentId` int(11) NOT NULL AUTO_INCREMENT,
  `CreateDate` datetime NOT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyByUserId` datetime DEFAULT NULL,
  `Code` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0',
  `CompanyId` int(11) NOT NULL,
  PRIMARY KEY (`DepartmentId`),
  KEY `department_companyid` (`CompanyId`),
  CONSTRAINT `department_companyid` FOREIGN KEY (`CompanyId`) REFERENCES `ls_company` (`CompanyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `ls_department` */

/*Table structure for table `ls_role` */

DROP TABLE IF EXISTS `ls_role`;

CREATE TABLE `ls_role` (
  `RoleId` int(11) NOT NULL AUTO_INCREMENT,
  `DepartmentId` int(11) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyByUserId` datetime DEFAULT NULL,
  `Code` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`RoleId`),
  KEY `role_departmentid` (`DepartmentId`),
  CONSTRAINT `role_departmentid` FOREIGN KEY (`DepartmentId`) REFERENCES `ls_department` (`DepartmentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `ls_role` */

/*Table structure for table `ls_role_authority` */

DROP TABLE IF EXISTS `ls_role_authority`;

CREATE TABLE `ls_role_authority` (
  `RoleAuthorityId` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` int(11) NOT NULL,
  `AuthorityId` int(11) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyUserId` int(11) DEFAULT NULL,
  `IsDeleted` bit(1) NOT NULL,
  PRIMARY KEY (`RoleAuthorityId`),
  KEY `roleid` (`RoleId`),
  KEY `authorityid` (`AuthorityId`),
  CONSTRAINT `authorityid` FOREIGN KEY (`AuthorityId`) REFERENCES `ls_authority` (`AuthorityId`),
  CONSTRAINT `roleid` FOREIGN KEY (`RoleId`) REFERENCES `ls_role` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `ls_role_authority` */

/*Table structure for table `ls_user` */

DROP TABLE IF EXISTS `ls_user`;

CREATE TABLE `ls_user` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `Pwd` varchar(128) DEFAULT NULL,
  `Email` varchar(256) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `CreateByUserId` int(11) NOT NULL DEFAULT '0',
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  `LastLoginTime` datetime NOT NULL,
  `LastLoginIP` varchar(256) NOT NULL,
  `Status` varchar(32) NOT NULL DEFAULT 'ACTIVE',
  `IsDelete` bit(1) NOT NULL DEFAULT b'0',
  `Phone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  FULLTEXT KEY `account_inde` (`Email`),
  FULLTEXT KEY `account_phone` (`Phone`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `ls_user` */

insert  into `ls_user`(`UserId`,`Pwd`,`Email`,`CreateDate`,`CreateByUserId`,`ModifyDate`,`ModifyByUserId`,`LastLoginTime`,`LastLoginIP`,`Status`,`IsDelete`,`Phone`) values (2,'12345678','11.qqcc.com','2016-12-10 02:31:51',0,NULL,0,'2017-03-06 00:58:34','::1','ACTIVE','\0','13333343512'),(3,'2B0DE2A6735339D34581303705E3BCD8','randy','2017-03-07 00:30:29',0,NULL,0,'2017-03-07 00:31:41','::1','ACTIVE','\0',NULL);

/*Table structure for table `ls_user_info` */

DROP TABLE IF EXISTS `ls_user_info`;

CREATE TABLE `ls_user_info` (
  `UserInfoId` int(11) NOT NULL AUTO_INCREMENT,
  `RealName` varchar(64) DEFAULT NULL,
  `NickName` varchar(128) NOT NULL,
  `IdCardType` varchar(32) DEFAULT 'IDCARD',
  `IdCardNo` varchar(32) DEFAULT NULL,
  `Phone` varchar(32) DEFAULT NULL,
  `Tel` varchar(32) DEFAULT NULL,
  `Address` varchar(128) DEFAULT NULL,
  `Remark` text,
  `BirthDate` date DEFAULT NULL,
  `ExtendInfo` text,
  `UserId` int(11) NOT NULL,
  PRIMARY KEY (`UserInfoId`),
  KEY `userinfo_userid` (`UserId`),
  CONSTRAINT `userinfo_userid` FOREIGN KEY (`UserId`) REFERENCES `ls_user` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `ls_user_info` */

insert  into `ls_user_info`(`UserInfoId`,`RealName`,`NickName`,`IdCardType`,`IdCardNo`,`Phone`,`Tel`,`Address`,`Remark`,`BirthDate`,`ExtendInfo`,`UserId`) values (1,'颤三','olal的名字','idcard','440332222231930476','13450207954','020-65433567','广州天河','','2017-03-06','',3);

/*Table structure for table `ls_user_role` */

DROP TABLE IF EXISTS `ls_user_role`;

CREATE TABLE `ls_user_role` (
  `UserRoleId` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `CreateByUserId` int(11) DEFAULT NULL,
  `ModifyDate` datetime DEFAULT NULL,
  `ModifyByUserId` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserRoleId`),
  KEY `roldid` (`RoleId`),
  KEY `userid` (`UserId`),
  CONSTRAINT `roldid` FOREIGN KEY (`RoleId`) REFERENCES `ls_role` (`RoleId`),
  CONSTRAINT `userid` FOREIGN KEY (`UserId`) REFERENCES `ls_user` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `ls_user_role` */

/*Table structure for table `test` */

DROP TABLE IF EXISTS `test`;

CREATE TABLE `test` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) DEFAULT NULL,
  `Phone` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `test` */

insert  into `test`(`Id`,`Name`,`Phone`) values (1,'tom','22'),(2,'randy','111'),(3,'Jenny','110');

/* Procedure structure for procedure `P_GenerateModel` */

/*!50003 DROP PROCEDURE IF EXISTS  `P_GenerateModel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `P_GenerateModel`(##本存储过程不会在程序中调用,不需在线上执行，调用了函数 fun_GetCSTypeFromDbType 如果在其他库执行要注意,author:pukuimin
tableSchema VARCHAR(50),-- 用到的数据库
tableName VARCHAR(50) #要生成的类名
)
BEGIN
DECLARE count1_1 INT;
DECLARE retString VARCHAR(8000);
DECLARE table_name1,column_Name1,is_nullable1,data_type1,character_maximum_length1,column_comment1,Column_Key1 VARCHAR(100);
DECLARE REFERENCED_TABLE_NAME1,REFERENCED_COLUMN_NAME1 VARCHAR(100);
DECLARE pri_Column_Name,pri_data_type VARCHAR(100);
DECLARE lowerTableName VARCHAR(50);#小写表名，用于比较
DECLARE sColumns VARCHAR(800);#归档的列集合
DECLARE archiveSql VARCHAR(2000);#归档的SQL
-- 需要定义接收游标数据的变量 
-- 遍历数据结束标志
DECLARE done INT DEFAULT 0;
DECLARE cur CURSOR FOR SELECT table_name,column_Name,is_nullable,data_type,character_maximum_length,column_comment,Column_Key FROM information_schema.COLUMNS WHERE table_schema=tableSchema AND table_name = tableName;
DECLARE cur2 CURSOR FOR SELECT table_name,column_name,REFERENCED_TABLE_NAME,REFERENCED_COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE table_schema=tableSchema AND table_name = tableName;
-- 将结束标志绑定到游标
DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
SET retString = ''; #初始化为空串
SET lowerTableName=LOWER(tableName);
SET sColumns='';
SET retString=CONCAT(retString,'namespace YCF.Stock.Core.Entities
{
    using Abp.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using YCF.Stock.Core.Enum;
');
SET retString=CONCAT(retString,'    [Table("',tableName,'")]',CHAR(10));
SELECT column_Name,data_type INTO pri_Column_Name, pri_data_type FROM information_schema.COLUMNS WHERE table_schema=tableSchema AND table_name = tableName AND Column_Key='PRI' LIMIT 1;
SET retString=CONCAT(retString,'    public partial class ',tableName,' : Entity<',fun_GetCSTypeFromDbType(pri_data_type),'>',CHAR(10));
SET retString=CONCAT(retString,'    {',CHAR(10));
#set retString=CONCAT(retString,'//    priName:',pri_Column_Name,',priType:',pri_data_type,char(10));
-- 打开游标
OPEN cur;
-- 开始循环
read_loop: LOOP
    -- 提取游标里的数据，这里只有一个，多个的话也一样；
    FETCH cur INTO table_name1,column_Name1,is_nullable1,data_type1,character_maximum_length1,column_comment1,Column_Key1;
    -- 声明结束的时候
    IF done=1 THEN
      LEAVE read_loop;
    END IF;
    -- 这里做你想做的循环的事件
    #set retString=CONCAT(retString,'',CHAR(10));
    SET retString=CONCAT(retString,'
        /// <summary>
        /// ',column_comment1,'
        /// </summary>
');
SET sColumns=CONCAT(sColumns,column_Name1,',');#字段相连
IF data_type1='varchar' OR data_type1='varchar' THEN 
	SET retString=CONCAT(retString,'        [StringLength(',character_maximum_length1,')]
        [MaxLength(',character_maximum_length1,')]',CHAR(10));
ELSEIF data_type1='date' OR data_type1='bit' THEN 
	SET retString=CONCAT(retString,'        [Column(TypeName = "',data_type1,'")]',CHAR(10));
END IF;
IF Column_Key1='PRI' THEN 
	SET retString=CONCAT(retString,'        [Column("',column_Name1,'")]',CHAR(10),'        public override ',fun_GetCSTypeFromDbType(data_type1),' Id { get; set; }',CHAR(10));
ELSE
	SET retString=CONCAT(retString,'        public ',fun_GetCSTypeFromDbType(data_type1),CASE WHEN is_nullable1 ='YES' THEN '?' ELSE '' END,' ',column_Name1,' { get; set; }',CHAR(10));
END IF;
END LOOP;
CLOSE cur;-- 关闭游标
SET done=0;#重新把done标识为0，开始第二个游标
SET sColumns = LEFT(sColumns,LENGTH(sColumns)-1);
#set retString=CONCAT(retString,'// 列表 :',sColumns,CHAR(10));
SET archiveSql=CASE lowerTableName 
WHEN 'itemcontractprice' THEN CONCAT(' INSERT INTO `itemcontractpricearchive`(',sColumns,') SELECT  ',sColumns,' FROM `itemcontractprice` WHERE `Date` = archiveDate;',CHAR(10))
WHEN 'foreigncurrency' THEN CONCAT(' INSERT INTO `foreigncurrencyarchive`(',sColumns,') SELECT ',sColumns,' FROM `foreigncurrency` WHERE `ContractPriceId` IN(SELECT `ContractPriceId` FROM `itemcontractprice` WHERE `Date` = archiveDate);',CHAR(10))
WHEN 'itemcontractpricelog' THEN CONCAT(' INSERT INTO `itemcontractpricelogarchive`(',sColumns,') SELECT ',sColumns,' FROM `itemcontractpricelog` WHERE `ContractPriceId` IN(SELECT `ContractPriceId` FROM `itemcontractprice` WHERE `Date` = archiveDate);',CHAR(10))
WHEN 'itemcontractstock' THEN CONCAT(' INSERT INTO `itemcontractstockarchive`(',sColumns,') SELECT  ',sColumns,' FROM `itemcontractstock`  WHERE `Date` = archiveDate;',CHAR(10))
WHEN 'itemcontractstocklog' THEN CONCAT(' INSERT INTO `itemcontractstocklogarchive`(',sColumns,') SELECT  ',sColumns,' FROM `itemcontractstocklog` WHERE `StockId` IN(SELECT `StockId` FROM `itemcontractstock` WHERE `Date` = archiveDate);',CHAR(10))
WHEN 'itemcountlog' THEN CONCAT('INSERT INTO `itemcountlogarchive`(',sColumns,') SELECT ',sColumns,' FROM `itemcountlog` WHERE `ItemDate` = archiveDate;',CHAR(10))
WHEN 'itemsendstatus' THEN CONCAT('INSERT INTO `itemsendstatusarchive`(',sColumns,') SELECT ',sColumns,' FROM `itemsendstatus` WHERE `LogId` IN(SELECT `LogId` FROM `itemcountlog` WHERE `ItemDate` = archiveDate);',CHAR(10))
ELSE ''
END;
IF archiveSql!='' THEN 
	SET retString=CONCAT(retString,'//归档SQL:',archiveSql,CHAR(10));
END IF;
SET retString=CONCAT(retString,'/*',CHAR(10));
  -- 打开游标2
OPEN cur2;
-- 开始循环
  read_loop2: LOOP
      -- 提取游标里的数据，这里只有一个，多个的话也一样；
    FETCH cur2 INTO table_name1,column_Name1,REFERENCED_TABLE_NAME1,REFERENCED_COLUMN_NAME1;
    -- 声明结束的时候
    IF done=1 THEN
      LEAVE read_loop2;
    END IF;
    -- 这里做你想做的循环的事件
    #set retString=CONCAT(retString,'',CHAR(10));
    IF REFERENCED_TABLE_NAME1 IS NOT NULL THEN 
	SET retString=CONCAT(retString,'        public virtual ',REFERENCED_TABLE_NAME1,' ',REFERENCED_TABLE_NAME1,' { get; set; }',CHAR(10));
    END IF;
  END LOOP;
    -- 关闭游标2
CLOSE cur2;
SET retString=CONCAT(retString,'*/',CHAR(10));
  SET retString=CONCAT(retString,'#warning 因数据库表名全部自动小写，请手动调整导航属性 public virtual XXX XXX { get; set; }',CHAR(10));
SET retString=CONCAT(retString,'
    }
}',CHAR(10));
SELECT retString;  
END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
