/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50505
Source Host           : localhost:3306
Source Database       : db_toko

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2019-12-04 16:13:38
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
INSERT INTO `tb_barang` VALUES ('B0000001', 'BAUT 5/16X18\"', 'J001', 'S001', '10000', '100000', '0');
INSERT INTO `tb_barang` VALUES ('B0000002', 'STIKER HONDA', 'J002', 'S001', '10000', '10000', '0');
INSERT INTO `tb_barang` VALUES ('B0000003', 'KOMSTIR', 'J003', 'S002', '100000', '2000000', '0');

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
  `harga_beli` decimal(10,0) DEFAULT NULL,
  `harga_jual` decimal(10,0) DEFAULT NULL,
  `total` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_keranjang
-- ----------------------------

-- ----------------------------
-- Table structure for `tb_keranjang_antar`
-- ----------------------------
DROP TABLE IF EXISTS `tb_keranjang_antar`;
CREATE TABLE `tb_keranjang_antar` (
  `no` int(4) NOT NULL AUTO_INCREMENT,
  `kd_barang` varchar(16) DEFAULT NULL,
  `nama_barang` varchar(64) DEFAULT NULL,
  `satuan` varchar(32) DEFAULT NULL,
  `qty` int(8) DEFAULT NULL,
  `sisa` int(8) DEFAULT NULL,
  `antar` int(8) DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_keranjang_antar
-- ----------------------------
INSERT INTO `tb_keranjang_antar` VALUES ('1', 'B0000001', 'BAUT 5/16X18\"', 'PCS', '5', '2', '2');
INSERT INTO `tb_keranjang_antar` VALUES ('2', 'B0000002', 'STIKER HONDA', 'PCS', '5', '1', '1');
INSERT INTO `tb_keranjang_antar` VALUES ('3', 'B0000003', 'KOMSTIR', 'DOS', '5', '0', '0');

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
INSERT INTO `tb_pelanggan` VALUES ('PL000001', 'JASON', 'BARONANG', '123901293');
INSERT INTO `tb_pelanggan` VALUES ('PL000002', 'ACOS', 'BAROMBONK', '129301923');

-- ----------------------------
-- Table structure for `tb_pembelian`
-- ----------------------------
DROP TABLE IF EXISTS `tb_pembelian`;
CREATE TABLE `tb_pembelian` (
  `kd_pembelian` varchar(12) NOT NULL,
  `kd_bukti` varchar(32) DEFAULT NULL,
  `tanggal` date DEFAULT NULL,
  `kd_supplier` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`kd_pembelian`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_pembelian
-- ----------------------------
INSERT INTO `tb_pembelian` VALUES ('PBL191100001', null, '2019-11-22', 'SP000001');
INSERT INTO `tb_pembelian` VALUES ('PBL191100002', 'ajsnd123', '2019-11-24', 'SP000001');
INSERT INTO `tb_pembelian` VALUES ('PBL191200003', '', '2019-12-04', 'SP000001');

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
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191100001', 'B0000002', '5', '10000');
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191100001', 'B0000001', '10', '5000');
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191100001', 'B0000003', '5', '10000');
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191100002', 'B0000003', '5', '10000');
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191200003', 'B0000001', '5', '10000');
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191200003', 'B0000002', '10', '10000');
INSERT INTO `tb_pembelian_detail` VALUES ('PBL191200003', 'B0000003', '15', '100000');

-- ----------------------------
-- Table structure for `tb_penjualan`
-- ----------------------------
DROP TABLE IF EXISTS `tb_penjualan`;
CREATE TABLE `tb_penjualan` (
  `kd_penjualan` varchar(12) NOT NULL,
  `tanggal` date DEFAULT NULL,
  `kd_pelanggan` varchar(8) DEFAULT NULL,
  `status` char(1) DEFAULT NULL,
  PRIMARY KEY (`kd_penjualan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_penjualan
-- ----------------------------
INSERT INTO `tb_penjualan` VALUES ('PJL191200001', '2019-12-04', 'PL000001', 'S');
INSERT INTO `tb_penjualan` VALUES ('PJL191200002', '2019-12-04', 'PL000001', 'S');
INSERT INTO `tb_penjualan` VALUES ('PJL191200003', '2019-12-04', 'PL000002', 'P');

-- ----------------------------
-- Table structure for `tb_penjualan_detail`
-- ----------------------------
DROP TABLE IF EXISTS `tb_penjualan_detail`;
CREATE TABLE `tb_penjualan_detail` (
  `kd_penjualan` varchar(12) DEFAULT NULL,
  `kd_barang` varchar(16) DEFAULT NULL,
  `qty` int(8) DEFAULT NULL,
  `ambil` int(8) DEFAULT NULL,
  `harga_beli` decimal(10,0) DEFAULT NULL,
  `harga_jual` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_penjualan_detail
-- ----------------------------
INSERT INTO `tb_penjualan_detail` VALUES ('PJL191200001', 'B0000001', '2', '2', '5000', '100000');
INSERT INTO `tb_penjualan_detail` VALUES ('PJL191200001', 'B0000003', '15', '15', '10000', '2000000');
INSERT INTO `tb_penjualan_detail` VALUES ('PJL191200002', 'B0000002', '5', '5', '10000', '10000');
INSERT INTO `tb_penjualan_detail` VALUES ('PJL191200002', 'B0000003', '10', '10', '100000', '2000000');
INSERT INTO `tb_penjualan_detail` VALUES ('PJL191200003', 'B0000001', '5', '1', '10000', '100000');
INSERT INTO `tb_penjualan_detail` VALUES ('PJL191200003', 'B0000002', '5', '2', '10000', '10000');
INSERT INTO `tb_penjualan_detail` VALUES ('PJL191200003', 'B0000003', '5', '3', '100000', '2000000');

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
-- Table structure for `tb_sopir`
-- ----------------------------
DROP TABLE IF EXISTS `tb_sopir`;
CREATE TABLE `tb_sopir` (
  `kd_sopir` varchar(4) NOT NULL,
  `nama_sopir` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`kd_sopir`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_sopir
-- ----------------------------
INSERT INTO `tb_sopir` VALUES ('SR01', 'MARKUS');
INSERT INTO `tb_sopir` VALUES ('SR02', 'ACO');

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

-- ----------------------------
-- Table structure for `tb_suratjalan`
-- ----------------------------
DROP TABLE IF EXISTS `tb_suratjalan`;
CREATE TABLE `tb_suratjalan` (
  `kd_suratjalan` varchar(12) NOT NULL,
  `tanggal` date DEFAULT NULL,
  `kd_penjualan` varchar(12) DEFAULT NULL,
  `alamat` varchar(32) DEFAULT NULL,
  `no_telp` varchar(16) DEFAULT NULL,
  `nama_sopir` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`kd_suratjalan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_suratjalan
-- ----------------------------
INSERT INTO `tb_suratjalan` VALUES ('SJL191200001', '2019-12-04', 'PJL191200008', 'BARONANG', '123901293', 'MARKUS');
INSERT INTO `tb_suratjalan` VALUES ('SJL191200002', '2019-12-04', 'PJL191200008', 'SERIGALA', '878221', 'ACO');
INSERT INTO `tb_suratjalan` VALUES ('SJL191200003', '2019-12-04', 'PJL191200003', 'SERIGALA', '878221', 'MARKUS');
INSERT INTO `tb_suratjalan` VALUES ('SJL191200004', '2019-12-04', 'PJL191200003', 'BAROMBONK', '129301923', 'ACO');

-- ----------------------------
-- Table structure for `tb_suratjalan_detail`
-- ----------------------------
DROP TABLE IF EXISTS `tb_suratjalan_detail`;
CREATE TABLE `tb_suratjalan_detail` (
  `kd_suratjalan` varchar(12) DEFAULT NULL,
  `kd_barang` varchar(16) DEFAULT NULL,
  `antar` int(8) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of tb_suratjalan_detail
-- ----------------------------
INSERT INTO `tb_suratjalan_detail` VALUES ('SJL191200002', 'B0000001', '0');
INSERT INTO `tb_suratjalan_detail` VALUES ('SJL191200002', 'B0000003', '5');
INSERT INTO `tb_suratjalan_detail` VALUES ('SJL191200003', 'B0000001', '1');
INSERT INTO `tb_suratjalan_detail` VALUES ('SJL191200003', 'B0000002', '1');
INSERT INTO `tb_suratjalan_detail` VALUES ('SJL191200003', 'B0000003', '1');
INSERT INTO `tb_suratjalan_detail` VALUES ('SJL191200004', 'B0000001', '1');
INSERT INTO `tb_suratjalan_detail` VALUES ('SJL191200004', 'B0000002', '1');
INSERT INTO `tb_suratjalan_detail` VALUES ('SJL191200004', 'B0000003', '1');
DROP TRIGGER IF EXISTS `menambah stok`;
DELIMITER ;;
CREATE TRIGGER `menambah stok` AFTER INSERT ON `tb_pembelian_detail` FOR EACH ROW BEGIN
UPDATE tb_barang tb
SET
tb.harga_beli = NEW.harga,
tb.stok = tb.stok + NEW.qty
WHERE
tb.kd_barang = NEW.kd_barang;
END
;;
DELIMITER ;
DROP TRIGGER IF EXISTS `mengurangi stok`;
DELIMITER ;;
CREATE TRIGGER `mengurangi stok` AFTER INSERT ON `tb_penjualan_detail` FOR EACH ROW BEGIN
UPDATE tb_barang tb
SET
tb.stok = tb.stok - NEW.qty
WHERE
tb.kd_barang = NEW.kd_barang;
END
;;
DELIMITER ;
