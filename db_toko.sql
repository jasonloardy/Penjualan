/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : db_toko

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2019-11-21 13:45:50
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `tb_barang`
-- ----------------------------
DROP TABLE IF EXISTS `tb_barang`;
CREATE TABLE `tb_barang` (
  `kd_barang` varchar(16) NOT NULL,
  `nama_barang` varchar(64) DEFAULT NULL,
  `kd_jenis` varchar(4) DEFAULT NULL,
  `kd_satuan` varchar(4) DEFAULT NULL,
  `harga_beli` decimal(10,0) DEFAULT NULL,
  `harga_jual` decimal(10,0) DEFAULT NULL,
  `stok` int(8) DEFAULT NULL,
  PRIMARY KEY (`kd_barang`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_barang
-- ----------------------------
INSERT INTO `tb_barang` VALUES ('B0000001', 'ASD', 'J001', 'S001', '500', '100000', '22');

-- ----------------------------
-- Table structure for `tb_jenis`
-- ----------------------------
DROP TABLE IF EXISTS `tb_jenis`;
CREATE TABLE `tb_jenis` (
  `kd_jenis` varchar(4) NOT NULL,
  `nama_jenis` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`kd_jenis`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_jenis
-- ----------------------------
INSERT INTO `tb_jenis` VALUES ('J001', 'BAUT');
INSERT INTO `tb_jenis` VALUES ('J002', 'KAP MOTOR');
INSERT INTO `tb_jenis` VALUES ('J003', 'KAP MOBIL');

-- ----------------------------
-- Table structure for `tb_keranjang`
-- ----------------------------
DROP TABLE IF EXISTS `tb_keranjang`;
CREATE TABLE `tb_keranjang` (
  `no` int(4) NOT NULL AUTO_INCREMENT,
  `kd_barang` varchar(16) DEFAULT NULL,
  `nama_barang` varchar(64) DEFAULT NULL,
  `satuan` varchar(32) DEFAULT NULL,
  `qty` int(8) DEFAULT NULL,
  `ambil` int(8) DEFAULT NULL,
  `harga` decimal(10,0) DEFAULT NULL,
  `total` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_keranjang
-- ----------------------------
INSERT INTO `tb_keranjang` VALUES ('1', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('2', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('3', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('4', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('6', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('7', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('8', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('9', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('10', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('11', 'B0000001', 'ASD', 'PCS', '5', '0', '60000', '300000');
INSERT INTO `tb_keranjang` VALUES ('12', 'B0000001', 'ASD', 'PCS', '5', '0', '6000099', '30000495');
INSERT INTO `tb_keranjang` VALUES ('13', 'B0000001', 'ASD', 'PCS', '5', '0', '6000099', '30000495');
INSERT INTO `tb_keranjang` VALUES ('15', 'B0000001', 'ASD', 'PCS', '5', '0', '6000099', '30000495');
INSERT INTO `tb_keranjang` VALUES ('16', 'B0000001', 'ASD', 'PCS', '5', '0', '6000099', '30000495');
INSERT INTO `tb_keranjang` VALUES ('17', 'B0000001', 'ASD', 'PCS', '5', '0', '6000099', '30000495');

-- ----------------------------
-- Table structure for `tb_pelanggan`
-- ----------------------------
DROP TABLE IF EXISTS `tb_pelanggan`;
CREATE TABLE `tb_pelanggan` (
  `kd_pelanggan` varchar(8) NOT NULL,
  `nama` varchar(32) DEFAULT NULL,
  `alamat` varchar(32) DEFAULT NULL,
  `no_telp` varchar(16) DEFAULT NULL,
  PRIMARY KEY (`kd_pelanggan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_pelanggan
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_pembelian`
-- ----------------------------
DROP TABLE IF EXISTS `tb_pembelian`;
CREATE TABLE `tb_pembelian` (
  `kd_pembelian` varchar(12) NOT NULL,
  `tanggal` date DEFAULT NULL,
  `kd_supplier` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`kd_pembelian`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_pembelian
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_satuan`
-- ----------------------------
DROP TABLE IF EXISTS `tb_satuan`;
CREATE TABLE `tb_satuan` (
  `kd_satuan` varchar(4) NOT NULL,
  `nama_satuan` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`kd_satuan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_satuan
-- ----------------------------
INSERT INTO `tb_satuan` VALUES ('S001', 'PCS');
INSERT INTO `tb_satuan` VALUES ('S002', 'DOS');
INSERT INTO `tb_satuan` VALUES ('S003', 'LUSIN');

-- ----------------------------
-- Table structure for `tb_supplier`
-- ----------------------------
DROP TABLE IF EXISTS `tb_supplier`;
CREATE TABLE `tb_supplier` (
  `kd_supplier` varchar(8) NOT NULL,
  `nama` varchar(32) DEFAULT NULL,
  `alamat` varchar(32) DEFAULT NULL,
  `no_telp` varchar(16) DEFAULT NULL,
  PRIMARY KEY (`kd_supplier`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_supplier
-- ----------------------------
INSERT INTO `tb_supplier` VALUES ('SP000001', 'ASD', 'ANUGERAH MAS', '21309123');
