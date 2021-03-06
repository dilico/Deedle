﻿// This is an interface file for F# Data component referenced via Paket. We use this 
// to mark all F# Data types & modules as internal, so that they are private to Deedle.
//
// When updating to a new version of F# Data, this may need to be updated. The easiest way
// is to go through the *.fs files, Alt+Enter them into F# Interactive & copy the output.
module FSharp.Data.Runtime.StructuralInference

open System
open System.Globalization
open FSharp.Data.Runtime.StructuralTypes

val internal supportsUnitsOfMeasure : typ:Type -> bool
val internal typeTag : _arg1:InferedType -> InferedTypeTag
val internal subtypeInfered : allowEmptyValues:bool -> ot1:InferedType -> ot2:InferedType -> InferedType
val internal unionCollectionOrder : order1:InferedTypeTag list -> order2:InferedTypeTag list -> InferedTypeTag list
val internal unionRecordTypes : allowEmptyValues:bool -> t1:InferedProperty list -> t2:InferedProperty list -> InferedProperty list
val internal inferCollectionType : allowEmptyValues:bool -> types:seq<InferedType> -> InferedType

val internal inferPrimitiveType : cultureInfo:CultureInfo -> value:string -> Type
val internal getInferedTypeFromString : cultureInfo:CultureInfo -> value:string -> unit:Type option -> InferedType

[<Interface>]
type internal IUnitsOfMeasureProvider =
  abstract member Inverse : denominator:Type -> Type
  abstract member Product : measure1:Type * measure2:Type -> Type
  abstract member SI : str:string -> Type

val internal defaultUnitsOfMeasureProvider : IUnitsOfMeasureProvider
val internal parseUnitOfMeasure : provider:IUnitsOfMeasureProvider -> str:string -> Type option
