/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : db_toko

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2019-11-21 15:47:22
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
INSERT INTO `tb_barang` VALUES ('B0000001', 'BAUT 5/16X18\"', 'J001', 'S001', '123000', '100000', '30');
INSERT INTO `tb_barang` VALUES ('B0000002', 'STIKER HONDA', 'J002', 'S001', '1', '10000', '35');
INSERT INTO `tb_barang` VALUES ('B0000003', 'KOMSTIR', 'J003', 'S002', '12300000', '2000000', '145');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_keranjang
-- ----------------------------
INSERT INTO `tb_keranjang` VALUES ('1', 'B0000002', 'STIKER HONDA', 'PCS', '1', '0', '10000', '10000');
INSERT INTO `tb_keranjang` VALUES ('2', 'B0000003', 'KOMSTIR', 'DOS', '1', '0', '100', '100');

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
INSERT INTO `tb_pembelian` VALUES ('PBL191100001', '2019-11-21', '');
INSERT INTO `tb_pembelian` VALUES ('PBL191100002', '2019-11-21', '');
INSERT INTO `tb_pembelian` VALUES ('PBL191100003', '2019-11-21', 'SP000001');

-- ----------------------------
-- Table structure for `tb_pembelian_detail`
-- ----------------------------
DROP TABLE IF EXISTS `tb_pembelian_detail`;
CREATE TABLE `tb_pembelian_detail` (
  `kd_pembelian` varchar(12) DEFAULT NULL,
  `kd_barang` varchar(16) DEFAULT NULL,
  `qty` int(8) DEFAULT NULL,
  `harga` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_pembelian_detail
-- ----------------------------
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191100001', 'B0000001', '8', '123000');
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191100001', 'B0000002', '20', '456000');
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191100002', 'b0000003', '45', '12300000');
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191100003', 'B0000002', '5', '1');

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
DROP TRIGGER IF EXISTS `update tb_barang`;
DELIMITER ;;
CREATE TRIGGER `update tb_barang` AFTER INSERT ON `tb_pembelian_detail` FOR EACH ROW BEGIN
UPDATE tb_barang tb
SET
tb.harga_beli = NEW.harga,
tb.stok = tb.stok + NEW.qty
WHERE
tb.kd_barang = NEW.kd_barang;
END
;;
DELIMITER ;
