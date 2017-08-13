<?php

/**
 * @author Hugo Figueroa Aguilera
 * @copyright 2017
 */
require 'constantes.php';
 class Conexion
 {
    public $mysqli;
    
    public function __construct()
    {
        $this->mysqli = new mysqli(SERVER,USER,PW,BD);
        $this->mysqli->query("SET NAMES 'utf8'");//Para poner el charset
    }
    
    public function conectado()
    {
        if($this->mysqli->connect_errno)
            print "Error al conectarse".$this->mysqli->connect_error;
        else print "";
    }
 }
 
 $prueba = new Conexion();
 $prueba->conectado();
 
?>